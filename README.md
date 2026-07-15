# 📱 Hypex Store

Интернет-магазин техники (ноутбуки, планшеты, телефоны, гаджеты, гарнитуры) — pet-проект / портфолио: красивый адаптивный фронт + полный рабочий цикл заказа.

Модульный монолит на **.NET 10** + SPA на **React 19 / Vite**, база — **PostgreSQL**.

| | |
|---|---|
| **Frontend** | React 19, TypeScript, Vite, Tailwind v4, Motion, TanStack Query, React Router, Zustand, react-i18next |
| **Backend** | .NET 10 (модульный монолит), EF Core 10, FluentValidation, JWT + refresh |
| **БД** | PostgreSQL 17 (Docker) |

## ✨ Возможности

- 🛍️ Каталог с фильтрами (категория / бренд / цена / наличие), поиском, сортировкой и пагинацией
- 📄 Страница товара: галерея, характеристики, отзывы и рейтинги
- ❤️ Избранное, ⚖️ сравнение товаров бок-о-бок, 🛒 корзина
- 📦 Оформление заказа (оплата при получении) + история заказов
- 🔐 Авторизация: покупатели и админ (JWT + refresh с ротацией)
- 🛠️ Админка: дашборд, CRUD товаров (переводы + атрибуты), категории/бренды, управление статусами заказов
- 🌍 Мультиязычность RU / UZ / EN, 🌗 тёмная/светлая тема, адаптив (mobile-first), motion-анимации, skeleton- и empty-состояния

## 📦 Требования

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- [Node.js 20+](https://nodejs.org/) (и npm)
- [Docker Desktop](https://www.docker.com/) — для PostgreSQL

## 🚀 Запуск (локально)

### 1. База данных

Скопируйте `.env.example` в `.env` и поднимите Postgres:

```bash
cd store_app
cp .env.example .env
docker compose up -d
```

> Порт Postgres на хосте — **5440** (`POSTGRES_PORT` в `.env`), т.к. 5432/5433 часто заняты другими инстансами. Строка подключения в `appsettings.json` уже указывает на `Port=5440`.

### 2. Backend (API на `http://localhost:5080`)

```bash
cd store_app/backend
dotnet run --project src/Hypex.Api
```

Миграции EF Core и seed данных (5 категорий, 12 брендов, 32 товара + админ) применяются **автоматически при старте**. Проверка: `GET http://localhost:5080/api/health` → `200 {"status":"ok"}`. Swagger/OpenAPI — в режиме Development.

### 3. Frontend (SPA на `http://localhost:5173`)

```bash
cd store_app/frontend
npm install
npm run dev
```

Vite проксирует `/api` → `http://localhost:5080`, так что фронт и API работают вместе без доп. настройки. Если 5173 занят, Vite выберет следующий свободный порт.

Откройте приложение по адресу **[localhost:5173](http://localhost:5173)**.

## 🔑 Учётные данные администратора (dev)

```
Email:    admin@hypex.local
Пароль:   Admin123!
```

Раздел админки доступен в шапке после входа под этой учёткой (`/admin`).

## 🧰 Полезные команды

**Frontend** (`store_app/frontend`):

| Команда | Действие |
|---|---|
| `npm run dev` | dev-сервер с HMR |
| `npm run build` | типизация (`tsc -b`) + production-сборка |
| `npm run preview` | предпросмотр production-сборки |
| `npm run lint` | oxlint |

**Backend** (`store_app/backend`):

| Команда | Действие |
|---|---|
| `dotnet build` | сборка solution |
| `dotnet run --project src/Hypex.Api` | запуск API (миграции + seed на старте) |

**База**: `docker compose up -d` / `docker compose down` (данные сохраняются в volume `hypex-pgdata`; `docker compose down -v` — сброс БД).

## 🏗️ Структура

```text
store_app/
├── backend/                      # .NET 10 — модульный монолит
│   └── src/
│       ├── Hypex.Api/            # Controllers, Program.cs, middleware, DI
│       ├── Hypex.Application/    # Use-cases, DTO, валидация, интерфейсы
│       ├── Hypex.Domain/         # Entities, enums, доменная логика
│       └── Hypex.Infrastructure/ # EF Core, репозитории, JWT, seed
├── frontend/                     # React + Vite (SPA)
│   └── src/
│       ├── app/                  # роутинг, providers, layout
│       ├── features/             # catalog, cart, auth, orders, admin, reviews…
│       └── shared/              # ui (дизайн-система), lib, api, store
├── docker-compose.yml            # PostgreSQL
└── .env.example
```

## 🔌 API (основные группы)

| Группа | Эндпоинты |
|---|---|
| **Auth** | `register`, `login`, `refresh`, `me` |
| **Catalog** | `GET products` (фильтры/сортировка/пагинация/поиск), `GET product/{slug}`, `categories`, `brands` |
| **Favorites** | `GET / POST / DELETE` (авторизованный) |
| **Reviews** | `GET` по товару, `POST` (авторизованный) |
| **Orders** | `POST` создать, `GET` мои заказы, `GET /{id}` |
| **Admin** | CRUD товаров/категорий/брендов, список и смена статусов заказов |

Дополнительно: локализация ответов по `?lang=` / `Accept-Language` (RU/UZ/EN, дефолт RU), глобальная обработка ошибок (ProblemDetails), FluentValidation, CORS, rate-limit на auth.

## 📝 Заметки

- Оплата — только при получении (без онлайн-платежей).
- Фото товаров — по URL / seed (без облачного хранилища).
- JWT-ключ и пароль БД в `appsettings.json` / `.env` — **dev-значения**, замените для продакшена.
