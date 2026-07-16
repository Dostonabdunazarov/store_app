# Сборка SPA (Vite) и раздача через nginx.
# API-запросы фронт шлёт на относительный /api (см. shared/api/client.ts),
# маршрутизацию /api/* → backend делает общий Caddy — VITE_API_URL не нужен.
FROM node:22-alpine AS builder
WORKDIR /app
COPY package*.json ./
RUN npm ci
COPY . .
RUN npm run build

FROM nginx:alpine
COPY --from=builder /app/dist /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
