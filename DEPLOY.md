# Деплой — store.hypex.site

Модель та же, что у остальных проектов Hypex: единый обратный прокси **Caddy**
(живёт в репозитории `corpdev`, каталог `infra/`) слушает :80 и по домену
маршрутизирует запросы на контейнеры проектов через общую docker-сеть `proxy`.
**TLS терминирует Cloudflare** — до сервера трафик идёт по HTTP.

```text
Браузер → Cloudflare (HTTPS) → сервер :80 → Caddy → store-frontend / store-backend
```

Caddy для `store.hypex.site`: `/api/*` → `store-backend:8080`, остальное → `store-frontend:80`.
Фронт обращается к API по относительному `/api`, поэтому отдельный origin/URL не нужен.

## Состав

| Файл | Назначение |
|---|---|
| `backend/Dockerfile` | сборка .NET 10 API (`src/Hypex.Api`) |
| `frontend/Dockerfile` + `frontend/nginx.conf` | сборка SPA (Vite) → раздача nginx |
| `docker-compose.yml` | базовый (dev): postgres + backend + frontend, порты на 127.0.0.1 |
| `docker-compose.prod.yml` | прод-оверлей: сеть `proxy`, Production, секреты из `.env` |
| `.github/workflows/deploy.yml` | автодеплой по push в `main` (SSH) |

## Первичная настройка на сервере (один раз)

Предполагается, что общий прокси уже поднят (`corpdev/infra`, сеть `proxy`).

1. **Клонировать репозиторий** рядом с остальными:
   ```bash
   cd /root && git clone <repo-url> store_app && cd store_app
   ```
2. **Создать `.env`** с прод-секретами (не коммитится):
   ```bash
   cat > .env <<'EOF'
   POSTGRES_USER=hypex
   POSTGRES_DB=hypex
   POSTGRES_PASSWORD=<сгенерировать: openssl rand -base64 48>
   JWT_KEY=<сгенерировать: openssl rand -base64 48>
   CORS_ALLOWED_ORIGIN=https://store.hypex.site
   EOF
   ```
3. **Cloudflare**: A/CNAME-запись `store` → IP сервера, оранжевое облачко (proxied).
4. **Маршрут Caddy** уже добавлен в `corpdev/infra/Caddyfile` (блок `store.hypex.site`).
   На сервере обновить corpdev и перечитать конфиг:
   ```bash
   cd /root/corpdev && git pull
   docker compose -f infra/docker-compose.yml exec -T caddy caddy reload --config /etc/caddy/Caddyfile
   ```
5. **Поднять проект**:
   ```bash
   cd /root/store_app
   docker compose -f docker-compose.yml -f docker-compose.prod.yml up -d --build
   ```

## Автодеплой (GitHub Actions)

Push в `main` → workflow подключается по SSH и на сервере делает
`git reset --hard`, пересобирает и поднимает контейнеры, перечитывает Caddy.

Нужны секреты репозитория: `SSH_HOST`, `SSH_USER`, `SSH_PRIVATE_KEY`.

## Проверка

```bash
# health API через прокси
curl -s -H "Host: store.hypex.site" http://localhost/api/health   # → {"status":"ok",...}
# фронт
curl -sI -H "Host: store.hypex.site" http://localhost/ | head -1  # → 200
docker compose logs -f backend
```

## ⚠️ Грабли (см. corpdev/infra/README.md)

- **nginx проекта НЕ жмёт gzip** — сжатие делают Caddy и Cloudflare. Иначе
  chunked-апстрим ломает проксирование (Content-Length: 0, белый экран).
  В `frontend/nginx.conf` `gzip` намеренно выключен.
- **После пересборки** контейнер получает новый IP в сети `proxy`. Если Caddy
  начал отдавать пустые ответы — `docker compose -f /root/corpdev/infra/docker-compose.yml restart caddy`.
- **Cloudflare кэширует** — при проблемах со статикой: Caching → Purge Everything,
  проверять в инкогнито.

## Миграции и seed

EF Core миграции и seed (категории/бренды/товары + админ) применяются
**автоматически при старте** backend (`DataSeeder.SeedAsync` в `Program.cs`).
Отдельного шага не требуется. Данные Postgres — в volume `hypex-pgdata`.

Админ по умолчанию: `admin@hypex.local` / `Admin123!` — **смените в проде**.
