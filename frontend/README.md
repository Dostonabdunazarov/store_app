# Hypex Store — Frontend

SPA магазина Hypex Store: **React 19 + TypeScript + Vite**, Tailwind v4, Motion, TanStack Query, React Router, Zustand, react-i18next (RU/UZ/EN).

> Полная инструкция по запуску всего проекта (БД + API + фронт) — в [../README.md](../README.md).

## Быстрый старт

```bash
npm install
npm run dev
```

Требуется запущенный API на `http://localhost:5080` — Vite проксирует туда `/api`. Фронт поднимется на `http://localhost:5173`.

## Команды

| Команда | Действие |
|---|---|
| `npm run dev` | dev-сервер с HMR |
| `npm run build` | `tsc -b` + production-сборка |
| `npm run preview` | предпросмотр production-сборки |
| `npm run lint` | oxlint |

## Структура

```text
src/
├── app/        # роутинг, providers, layout (навбар/футер)
├── features/   # catalog, product, cart, favorites, compare, checkout, orders, auth, admin
└── shared/
    ├── ui/     # дизайн-система (Button, Card, Input, Skeleton, …)
    ├── lib/    # утилиты, i18n, cn, форматтеры
    ├── api/    # axios-клиент, эндпоинты, типы, query-ключи
    └── store/  # zustand (cart, favorites, compare, auth, theme)
```

Дизайн-токены (цвета/отступы/типографика, светлая/тёмная тема) — в [src/index.css](src/index.css).
