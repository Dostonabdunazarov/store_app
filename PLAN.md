# 📱 Hypex Store — План проекта

Интернет-магазин техники: ноутбуки, планшеты, мобильные телефоны, гаджеты, гарнитуры.

## Стек

| Слой | Технологии |
|---|---|
| **Frontend** | React + Vite (SPA), TypeScript, Tailwind CSS, Motion, 21st.dev (Magic MCP), TanStack Query, React Router, Zustand, react-i18next |
| **Backend** | .NET 10 (модульный монолит), EF Core, FluentValidation, JWT + refresh |
| **БД** | PostgreSQL |
| **Инфра** | Docker Compose (Postgres), локальное хранение фото (URL/seed) |

## Вводные (утверждено)

| Параметр | Решение |
|---|---|
| Масштаб | MVP / портфолио — красивый фронт + рабочий цикл заказа |
| Auth | Полная: покупатели + роль администратора (JWT + refresh) |
| Оплата | При получении (без онлайн-платежей) |
| Ключевые фичи | Фильтры/поиск, Избранное, Сравнение, Отзывы/рейтинги, Мультиязычность RU/UZ/EN |
| Дизайн | Mobile-first, адаптивный, современный, тёмная/светлая тема, motion |
| Фото товаров | URL / seed (без облака) |

---

## 🏗️ Архитектура

```
HYPEX/store_app/
├── backend/                      # .NET 10 — модульный монолит
│   ├── src/
│   │   ├── Hypex.Api/            # Controllers, Program.cs, middleware, DI
│   │   ├── Hypex.Application/    # Use-cases, DTO, validation, интерфейсы
│   │   ├── Hypex.Domain/         # Entities, enums, доменная логика
│   │   └── Hypex.Infrastructure/ # EF Core, репозитории, JWT, seed
│   └── Hypex.sln
│
└── frontend/                     # React + Vite
    ├── src/
    │   ├── app/                  # роутинг, providers, layout
    │   ├── features/            # catalog, cart, auth, orders, admin, reviews...
    │   ├── shared/ui/           # дизайн-система (кнопки, карточки, инпуты)
    │   ├── shared/lib/          # api-клиент, хуки, i18n, утилиты
    │   └── shared/store/        # zustand (cart, favorites, compare)
    └── ...
```

Модульный монолит: чистое разделение слоёв без микросервисной сложности — оптимально для MVP, легко расширяется.

---

## 🗄️ Модель данных (PostgreSQL / EF Core)

- **User** (Id, Email, PasswordHash, Role: Customer/Admin, RefreshTokens)
- **Category** (ноутбуки, планшеты, телефоны, гаджеты, гарнитуры) + **Brand**
- **Product** (Id, Slug, Price, Stock, CategoryId, BrandId, Rating, ImageUrls[])
- **ProductTranslation** (ProductId, Lang, Name, Description) — мультиязычность
- **ProductAttribute** (RAM, экран, процессор… key/value — для фильтров и сравнения)
- **Review** (ProductId, UserId, Rating 1–5, Comment, CreatedAt)
- **Favorite** (UserId, ProductId)
- **Order** + **OrderItem** (снимок цены, кол-во, статус: Pending → Confirmed → Delivered)
  - Order хранит контакты + адрес (оплата при получении)

---

## 🔌 API (основные эндпоинты)

| Группа | Эндпоинты |
|---|---|
| **Auth** | register, login, refresh, me |
| **Catalog** | GET products (фильтры/сортировка/пагинация/поиск), GET product/{slug}, categories, brands |
| **Favorites** | GET / POST / DELETE (авторизованный) |
| **Reviews** | GET по товару, POST (авторизованный) |
| **Orders** | POST создать, GET мои заказы, GET /{id} |
| **Admin** | CRUD товаров/категорий/брендов, список и смена статусов заказов |

Дополнительно: Swagger, глобальная обработка ошибок, FluentValidation, CORS, rate-limit на auth.

---

## 🎨 Frontend — страницы и UX

**Публичные:** Главная (hero + motion), Каталог (сайдбар-фильтры + сетка), Товар (галерея, характеристики, отзывы, «в избранное/сравнить»), Сравнение (таблица бок-о-бок), Избранное, Корзина, Checkout, Мои заказы.

**Админка:** Дашборд, товары (CRUD), заказы (смена статуса).

**Дизайн-принципы:**
- Mobile-first, адаптив на всех брейкпоинтах, тёмная/светлая тема
- Motion — плавные появления, hover-эффекты карточек, переходы страниц, skeleton-загрузка
- 21st.dev компоненты через Magic MCP для сложных блоков (hero, карточки, навбар)
- Дизайн-система на Tailwind: единые токены цвета/отступов/типографики
- i18n через react-i18next (RU/UZ/EN), переключатель языка в шапке

---

## 📅 Этапы реализации

Легенда: ⬜ не начато · 🟡 в процессе · ✅ готово

### ✅ Фаза 0 — Каркас
solution .NET + Vite проект, Docker Compose для Postgres, структура папок, дизайн-токены Tailwind.

- [x] Структура папок `backend/` и `frontend/`
- [x] .NET solution (`.slnx`) + 4 проекта (Api, Application, Domain, Infrastructure) со ссылками
- [x] Docker Compose для Postgres + `.env` / `.env.example`
- [x] Vite + React + TS проект (React 19, Vite 8) + зависимости стека
- [x] Tailwind v4 + дизайн-токены (цвета, отступы, типографика, светлая/тёмная тема)
- [x] `.gitignore`, `Program.cs` (health `GET /api/health` → 200, CORS, DbContext), `App.tsx` (переключатель темы)

**Сделано также:** NuGet-пакеты EF Core 10 + Npgsql, JWT Bearer, FluentValidation; `HypexDbContext` + DI-расширение `AddInfrastructure`; connection string + JWT-настройки в `appsettings.json`; alias `@/` + прокси `/api` → `:5080` в Vite. API-порт: **5080**, фронт: **5173**.

**Проверено:** `dotnet build` — 0 ошибок; `npm run build` — успешно; API запущен, `/api/health` вернул `200 {"status":"ok"}`.
_Примечание: в Фазе 1 порт Postgres изменён с 5432 на **5440** из-за конфликта с другими Postgres на машине (см. Фазу 1)._

### ✅ Фаза 1 — Backend ядро
EF-модель + миграции + seed (реальные товары техники с характеристиками), Auth (JWT+refresh, роли), CRUD-каталог с фильтрами/поиском/пагинацией.

- [x] Domain entities (User, RefreshToken, Category, Brand, Product, ProductTranslation, ProductAttribute, Review, Favorite, Order, OrderItem) + enums (UserRole, OrderStatus, Languages)
- [x] EF Core DbContext + конфигурации + первая миграция (`InitialCreate`, применена — 13 таблиц)
- [x] Seed реальных товаров: 5 категорий, 12 брендов, **32 товара** с характеристиками и переводами RU/UZ/EN + admin-пользователь (идемпотентный `DataSeeder`, запускается на старте)
- [x] Auth: register / login / refresh / me (JWT + refresh с ротацией токенов, PBKDF2-хеш, роли Customer/Admin, FluentValidation)
- [x] Catalog: GET products (фильтры category/brand/price/inStock + поиск + сортировка + пагинация), GET product/{slug}, categories, brands

**Сделано также:** слоистая архитектура (Application-интерфейсы + Infrastructure-реализации); локализация ответов по `?lang=` / `Accept-Language` (default RU) с фолбэком на RU; глобальный обработчик ошибок (`AppException` → ProblemDetails); JWT Bearer + авторизация; CORS.

**⚠️ Порт Postgres изменён на `5440`** (`.env`, `docker-compose`, `appsettings.json`): порты 5432 и 5433 заняты другими инстансами Postgres на машине (чужой Docker-контейнер + нативный Windows-postgres). Контейнер: `hypex-postgres`.

**Проверено (E2E, API на :5080):** миграция применена; seed отработал (admin + 5 cat + 12 brands + 32 products); каталог — пагинация (32 товара/16 стр.), фильтры (phones=8, price 100–300=7, inStock=29/32), поиск (`macbook`+apple=2), сортировка, локализация RU/UZ/EN названий/описаний/атрибутов, 404 на несуществующий slug; auth — register→me→refresh (ротация: старый refresh отзывается → 401), login, admin (role=1), дубль email→409, неверный пароль→401, валидация→400 с ошибками по полям.

_Учётка админа для локальной разработки: `admin@hypex.local` / `Admin123!`._

### ✅ Фаза 2 — Backend фичи
Favorites, Reviews/рейтинги, Orders, Admin-эндпоинты, Swagger, валидация.

- [x] Favorites (GET/POST/DELETE)
- [x] Reviews + пересчёт рейтинга
- [x] Orders (создать, мои заказы, детали)
- [x] Admin CRUD товаров/категорий/брендов + управление заказами
- [x] Swagger/OpenAPI, глобальная обработка ошибок, FluentValidation, CORS, rate-limit на auth

### ✅ Фаза 3 — Frontend фундамент
дизайн-система + shared/ui, layout+навбар+футер, api-клиент, i18n, роутинг, auth-флоу.

- [x] shared/ui (Button, Card, Input, Select, Badge, Skeleton, Spinner, Container, ThemeToggle, LangSwitcher, PageSpinner)
- [x] Layout + навбар + футер + переключатель темы/языка (RootLayout + Navbar с моб. drawer + Footer)
- [x] api-клиент (axios + TanStack Query) + interceptor refresh (single-flight ротация токенов, Accept-Language, обработка ошибок ProblemDetails/Validation)
- [x] i18n RU/UZ/EN (react-i18next + language-detector, локали ru/uz/en, смена языка инвалидирует queries)
- [x] Роутинг + защищённые маршруты (react-router, `ProtectedRoute` + `adminOnly`, плейсхолдеры для фаз 4–6)
- [x] Auth-флоу (LoginPage/RegisterPage + zustand-store, bootstrap сессии из refresh-токена)

**Сделано также:** структура `src/app` (layout/providers/routes) + `src/features` + `src/shared` (ui/lib/api/store); типы API 1-в-1 по контракту бэкенда (camelCase, enum-числа, `PagedResult<T>`); `tokenStorage` (access в памяти, refresh в localStorage); дизайн-токены переиспользованы из Фазы 0; store темы с persist + применением `data-theme`.

**Проверено:** `tsc -b` + `vite build` — 0 ошибок; `oxlint` — чисто; dev-сервер отдаёт приложение, прокси `/api` → `:5080` работает (health + products с локализацией). E2E контракта против живого API (:5080): login admin (role=1), me по Bearer, refresh с ротацией, `Accept-Language` локализует названия (uz), валидация возвращает `errors` с PascalCase-ключами (клиент приводит к camelCase полей формы). **Рендер в headless Chrome:** главная (навбар + hero + футер) и `/login` (форма с email/password) монтируются и отрисовываются, клиентская навигация работает.

_Примечание: dev-порт Vite может смещаться (5173→5175), если 5173/5174 заняты — Vite сам выбирает свободный._

### ✅ Фаза 4 — Frontend витрина
Главная, Каталог с фильтрами, страница товара, поиск, motion-анимации.

- [x] Главная (hero + motion): hero с градиентными blur-пятнами, value-props, сетка категорий (эмодзи-иконки, счётчик товаров), блок «Популярные товары» (sort=rating), scroll-reveal через `whileInView`
- [x] Каталог (сайдбар-фильтры + сетка + пагинация): фильтры category/brand/price/inStock, все состояния фильтров синхронизированы с URL (`useSearchParams`), сортировка, мобильный drawer фильтров (motion), пагинация с эллипсисом, `keepPreviousData` для плавного пейджинга
- [x] Страница товара (галерея, характеристики, отзывы): breadcrumb, галерея с превью-переключателем, badge наличия (in stock/low stock/out), характеристики (`<dl>`), секция отзывов (список + форма с оценкой звёздами для авторизованных, login-prompt для гостей, инвалидация product+reviews после отправки). Кнопки «В корзину»/избранное — плейсхолдеры (Фаза 5)
- [x] Поиск: строка поиска в шапке каталога (submit по Enter → `?search=`)
- [x] Motion-анимации, skeleton-загрузка: fade-up карточек и секций, переходы галереи/drawer; `ProductCardSkeleton` + skeleton страницы товара + spinner отзывов

**Сделано также:** shared-компоненты `StarRating` (read-only + интерактивный, дробная заливка через SVG clipPath), `ProductImage` (lazy + graceful-плейсхолдер для битых/пустых URL), `Pagination` (компактный список с эллипсисом); утилиты `formatPrice`/`formatDate` (локализованный `Intl` по текущему языку); хуки каталога (`useProducts`/`useProduct`/`useCategories`/`useBrands`) и отзывов (`useReviews`/`useCreateReview`); i18n-ключи `home`/`catalog`/`product` в ru/uz/en; роуты `/catalog` и `/product/:slug` подключены вместо плейсхолдеров.

**Проверено:** `tsc -b` + `oxlint` + `vite build` — 0 ошибок. **Рендер в headless Chrome против живого API (:5080 через Vite-прокси):** главная — hero + featured (iPhone/MacBook/Sony) с картинками; каталог — заголовок, «32 products», 12 карточек с картинками, цены (`149 UZS` — `formatPrice`), пагинация; фильтр `?category=phones` сужает выдачу; страница товара `iphone-15-pro-max` — `<h1>` = «iPhone 15 Pro Max», цена `1,199 UZS`, галерея (4 img), «Specifications» + 7 атрибутов (A17 Pro, 512…), секция «Reviews» с login-prompt. Язык детектора в браузере — `en` (текст «Catalog»/«products»/«UZS»), i18n-интерполяция (`resultsCount`, `stockLeft`) работает.

### ✅ Фаза 5 — Frontend commerce
Корзина, избранное, сравнение, checkout, мои заказы.

- [x] Корзина (zustand + persist): store со снимком товара (id/slug/name/price/imageUrl/stock/qty), селекторы count/total; страница корзины (список, степпер кол-ва с клампом по stock, удаление, очистка, сводка, CTA к checkout); бейдж-счётчик в навбаре (десктоп-иконка + пункт в моб. drawer); кнопка «в корзину» на карточке товара и на странице товара (со степпером + «Купить сейчас» → корзина)
- [x] Избранное: серверное для авторизованных (`favoritesApi` + TanStack Query) + локальный persist-store для гостей со снимком товара; unified-хук `useFavoriteToggle`; sync гостевого избранного на сервер при входе (`useFavoritesSync`, монтируется в RootLayout); кнопка-сердечко (motion) на карточке и странице товара; страница избранного (grid, удаление, «в корзину»)
- [x] Сравнение (таблица бок-о-бок): local persist-store со slug'ами (кап `COMPARE_LIMIT=4`), кнопка-переключатель на карточке/странице товара (disabled при переполнении), бейдж-счётчик в навбаре; страница сравнения (`useQueries` по slug'ам, объединение ключей атрибутов, строки цена/рейтинг/бренд/наличие/атрибуты, удаление колонки, «в корзину»)
- [x] Checkout: защищённый маршрут; форма (контакты + адрес + комментарий, префилл имени из профиля), клиентская валидация обязательных полей + маппинг серверных ошибок (`getFieldErrors`); сводка заказа; создание заказа (`useCreateOrder`) → очистка корзины → редирект на детали заказа с флагом `justPlaced`
- [x] Мои заказы: список (`useOrders`, статус-бейдж, кол-во товаров, сумма, дата) + детали заказа (`useOrder`: позиции-снимки, доставка/контакты, сумма, success-баннер при `justPlaced`); общий компонент `OrderStatusBadge` (тон+локализация по статусу)

**Сделано также:** shared-компонент `QuantityStepper` (−/N/+ с клампом); хуки `orderHooks`/`favoriteHooks`; типы `CartableProduct`/`FavoritableProduct` (минимальный контракт для store'ов, чтобы добавлять из карточки/детали/избранного без каста); i18n-ключи `cart`/`favorites`/`compare`/`checkout`/`orders` в ru/uz/en (включая плюрализацию `itemsCount` и локализованные статусы заказа); роуты Фазы 5 подключены вместо плейсхолдеров; попутно исправлен pre-existing React-warning об отсутствии `key` в `FilterSidebar` и добавлен `aria-label` кнопке сравнения.

**Проверено:** `tsc -b` + `oxlint` + `vite build` — 0 ошибок. **E2E в headless Chrome против живого API (:5080 через Vite-прокси, UI=en):** каталог (12 карточек, 11 кнопок «в корзину») → добавление 2 товаров → бейдж корзины «2»; сердечко + сравнение на карточках → бейдж сравнения «2»; страница корзины (h1 «Cart», 2 позиции, степпер +1 → бейдж «3»); страница сравнения (2 колонки товаров, 12 строк атрибутов); избранное (1 гостевой товар); `/checkout` без авторизации → редирект на `/login`; вход admin → checkout → заполнение формы → заказ создан (редирект `/orders/:id`, success-баннер + статус-бейдж отрисованы) → корзина очищена; список заказов показывает созданный заказ. 401-логи в консоли — штатная прозрачная ротация токена (интерцептор Фазы 3), поток проходит успешно.

### ✅ Фаза 6 — Админка
Дашборд, CRUD товаров (с переводами и атрибутами), управление заказами, CRUD категорий/брендов.

- [x] Дашборд: 4 стат-тайла (всего заказов, выручка по статусам Confirmed/Shipped/Delivered, ожидают, активных товаров), баннер «нет в наличии», список последних заказов со статус-бейджами
- [x] Товары (CRUD): список (поиск, картинка, бейджи наличия/скрыт, цена), форма создания/редактирования с переводами RU/UZ/EN (name+description через языковые табы), атрибуты (key/label/value на язык), slug/цена/склад/категория/бренд/картинки/isActive; удаление — мягкое (`IsActive=false`)
- [x] Заказы (смена статуса): список всех заказов (контакты, адрес, сумма, дата, разворачиваемые позиции), смена статуса через `<Select>` (Pending→Confirmed→Shipped→Delivered→Cancelled) с оптимистичной инвалидацией
- [x] Категории и бренды (CRUD): инлайн-редакторы; категории с переводами названий RU/UZ/EN; удаление блокируется при наличии товаров (409); бренды (slug/name/logoUrl)

**Backend-доработки:** `ProductUpsertRequest` расширен полями `Translations` (lang/name/description) и `Attributes` (lang/key/label/value/sortOrder); admin product create/update теперь возвращают `AdminProductDto` (все языки + атрибуты, без циклов навигации) вместо сырой EF-сущности; добавлены `GET /admin/products` и `GET /admin/products/{id}`; category/brand create/update возвращают плоские `AdminCategoryDto`/`AdminBrandDto` (устранён `JsonException: object cycle`). Валидатор товара: slug-паттерн + обязательный ≥1 перевод + проверки атрибутов. Update товара/категории заменяет дочерние коллекции через `ExecuteDeleteAsync` + `AddRange` (устранён `DbUpdateConcurrencyException`). **Исправлен pre-existing баг сидера:** явные Id категорий/брендов не двигали Postgres-identity-sequence → `DataSeeder.SyncIdentitySequencesAsync` выравнивает sequence к `MAX(Id)` на старте (иначе admin-создание категории/бренда падало с `23505 duplicate key`).

**Frontend:** feature `admin/` (AdminLayout с сайдбар-навигацией, DashboardPage, AdminOrdersPage, AdminProductsPage, ProductFormPage, AdminCatalogPage, adminHooks); `adminApi` + типы (`AdminProductDto`, `ProductUpsertRequest`, `CategoryUpsertRequest`, `BrandUpsertRequest` и др.) + query-ключи `admin.*`; вложенные защищённые роуты `/admin`, `/admin/orders`, `/admin/products`, `/admin/products/new`, `/admin/products/:id/edit`, `/admin/catalog` (все под `ProtectedRoute adminOnly`); i18n-ключи `admin.*` в ru/uz/en.

**Проверено:** `tsc -b` + `oxlint` + `vite build` — 0 ошибок. **E2E API (:5080):** товар create (409 на дубль slug, 400 на пустые переводы) → update (переводы 2→1, атрибуты 1→2, смена категории/бренда/цены) → публичная страница товара отражает изменения → мягкое удаление → публичный 404; смена статуса заказа (204, статус персистится); категория create/update/delete (en-имя персистится, 409 при наличии товаров); бренд create/update/delete. **E2E UI (headless Chrome против живого стека, :5175 через Vite-прокси, UI=en):** логин админа → дашборд (4 тайла + последние заказы) → страница заказов (смена статуса 1→2 персистится) → товары (36 кнопок edit, «New product») → создание товара через форму (появляется в списке) → редактирование (форма гидратируется slug'ом, update, редирект) → удаление → страница «Категории и бренды» рендерит обе секции. Тестовые товары вычищены из БД после прогона.

### ✅ Фаза 7 — Полировка
адаптив/тёмная тема, skeleton-состояния, empty-states, README + инструкция запуска.

- [x] Адаптив на всех брейкпоинтах + тёмная тема
- [x] Skeleton-состояния + empty-states
- [x] README + инструкция запуска

**Сделано:** адаптив и тёмная/светлая тема реализованы сквозь фазы 4–6 (mobile-first сетки, моб. drawer'ы навбара/фильтров, семантические токены `data-theme` в [index.css](frontend/src/index.css) для обеих тем, `prefers-reduced-motion`) — в этой фазе проверены и оставлены как есть. **Skeleton-состояния** унифицированы: списковые/детальные экраны, где загрузка показывалась центрированным спиннером, переведены на layout-matching skeleton'ы — заказы (список + деталь), избранное (сетка карточек через `ProductCardSkeleton`), сравнение (колонки-заготовки), админ-дашборд (стат-тайлы + список), админ-товары и админ-заказы. Каталог/главная/страница товара уже использовали skeleton'ы с фазы 4. **Empty-states** уже присутствовали на всех экранах (корзина/избранное/сравнение/заказы/каталог/админ) — иконка + заголовок + подсказка + CTA. **README:** добавлен корневой [README.md](README.md) (стек, возможности, требования, пошаговый запуск БД→API→фронт, dev-учётка админа, команды, структура, API) + заменён Vite-boilerplate во [frontend/README.md](frontend/README.md) на проектный.

**Проверено:** `tsc -b` (exit 0) + `oxlint` (exit 0) + `vite build` — 0 ошибок.

---

## 🌱 Seed / демо-данные

Весь каталог — это **seed** (демо-данные), а не введённый вручную контент. Всё лежит в [backend/src/Hypex.Infrastructure/Persistence/Seed/](backend/src/Hypex.Infrastructure/Persistence/Seed/) и применяется **автоматически при старте API** ([Program.cs:63-67](backend/src/Hypex.Api/Program.cs#L63)) через `DataSeeder.SeedAsync()` — идемпотентно (каждый шаг no-op, если данные уже есть).

### Что засеивается

| Что | Где | Объём |
| --- | --- | --- |
| **Категории** | [SeedCatalog.cs](backend/src/Hypex.Infrastructure/Persistence/Seed/SeedCatalog.cs) | 5: ноутбуки, планшеты, смартфоны, гаджеты, гарнитуры (переводы RU/UZ/EN) |
| **Бренды** | [SeedCatalog.cs](backend/src/Hypex.Infrastructure/Persistence/Seed/SeedCatalog.cs) | 12: Apple, Samsung, Xiaomi, Sony, ASUS, Lenovo, Dell, HP, Google, JBL, Logitech, Huawei |
| **Товары** | [SeedCatalog.Products.cs](backend/src/Hypex.Infrastructure/Persistence/Seed/SeedCatalog.Products.cs) | 32 товара с переводами RU/UZ/EN, атрибутами, рейтингами и фото |
| **Admin-пользователь** | [DataSeeder.cs](backend/src/Hypex.Infrastructure/Persistence/Seed/DataSeeder.cs) | `admin@hypex.local` / `Admin123!` |

Категории и бренды используют **стабильные явные Id** (константы в `SeedCatalog.cs`), на которые ссылаются товары. `DataSeeder.SyncIdentitySequencesAsync` выравнивает Postgres-identity-sequence к `MAX(Id)` на старте (иначе admin-создание категории/бренда падало бы с `23505 duplicate key`).

### Фото товаров

- Фото — это **внешние URL** (по 2-3 на товар) прямо в [SeedCatalog.Products.cs](backend/src/Hypex.Infrastructure/Persistence/Seed/SeedCatalog.Products.cs); физических файлов картинок в репозитории нет.
- Изначально были заглушки `picsum.photos` (абстрактные картинки) → **заменены на настоящие фото техники с Unsplash** (`images.unsplash.com/photo-…?w=1200&q=80&auto=format&fit=crop`), подобранные под категорию/модель. Все URL проверены на HTTP 200.
- **`SyncProductImagesAsync`** ([DataSeeder.cs](backend/src/Hypex.Infrastructure/Persistence/Seed/DataSeeder.cs)) — идемпотентный шаг: на старте выравнивает `ImageUrls` уже засеянных товаров по slug под текущий seed. Это позволяет применять image-only правки без пересоздания БД (заказы/отзывы не тронуты).
- **`src/assets/hero.png`** — единственная статичная картинка в репозитории, используется как **фолбэк** в hero-карусели, если у featured-товаров нет фото ([HomePage.tsx](frontend/src/features/home/HomePage.tsx)).

### Чего нет

- Отдельных unit/integration-тестов, папок с фикстурами/моками в проекте **нет**. Совпадения по «placeholder/mock» в коде — это обычные UI-строки (placeholder у инпутов, i18n, skeleton-заглушки), а не тестовые данные.

### Как пересоздать данные

- **Точечно (фото):** правки `ImageUrls` в seed применяются на следующем старте API через `SyncProductImagesAsync`.
- **Полностью:** удалить том/контейнер Postgres (`hypex-postgres`) → на старте API заново применятся миграции + seed. Сотрёт все заказы/пользователей.

---

## 🖼️ Главная — hero-карусель (доработка)

- **Заголовок над каруселью:** бейдж (`home.heroBadge`) + `<h1>` «Новинки» (i18n-ключ `home.newArrivals` в RU/UZ/EN: «Новинки» / «Yangiliklar» / «New arrivals») в [HomePage.tsx](frontend/src/features/home/HomePage.tsx).
- **3-слойный coverflow** ([HeroCarousel.tsx](frontend/src/features/home/HeroCarousel.tsx)): крупный центральный слайд + два уменьшенных, наклонённых по оси Y («кривых») боковых слоя (через `perspective` + `transform-3d`, анимация `x/rotateY/scale/opacity/blur` на `motion`). Слайды строятся из топ-товаров по рейтингу. Сохранены автоплей (пауза на hover), стрелки, точки-индикаторы, деградация до одного слайда.

**Проверено:** `tsc -b` + `oxlint` + `dotnet build` — 0 ошибок; API отдаёт новые Unsplash-URL; скриншот главной в headless Chrome подтверждает заголовок, 3 слоя и загруженные фото.

---

## 🎨 Брендинг

**Hypex Store** — интернет-магазин техники.
