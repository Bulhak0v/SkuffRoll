# --- Етап 1: Збірка Фронтенду ---
FROM node:20-alpine AS build-frontend
WORKDIR /app

# Вказуємо повний шлях до package.json від кореня репозиторію
COPY WebClient/WebClient/wwwroot/package*.json ./
RUN npm ci

# Копіюємо решту файлів фронтенду
COPY WebClient/WebClient/wwwroot/ ./
RUN npm run build

# --- Етап 2: Збірка Бекенду ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-backend
WORKDIR /source

# Вказуємо повний шлях до файлу проєкту
COPY WebClient/WebClient/WebClient.csproj ./
RUN dotnet restore "WebClient.csproj"

# Копіюємо всі файли з папки проєкту
COPY WebClient/WebClient/ .
# Зверніть увагу на крапку в кінці!

# Копіюємо зібраний фронтенд з попереднього етапу
# УВАГА: Залишаємо '/app/build' для перевірки. Якщо не спрацює,
# будемо використовувати метод діагностики, який обговорювали.
COPY --from=build-frontend /app/build/ ./wwwroot

RUN dotnet publish "WebClient.csproj" -c Release -o /app/publish --no-restore

# --- Етап 3: Фінальний образ ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-backend /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "WebClient.dll"]