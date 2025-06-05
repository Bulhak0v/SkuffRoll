# --- Етап 1: Збірка Фронтенду (Node.js) ---
# Використовуємо офіційний образ Node.js.
FROM node:20-alpine AS build-frontend
WORKDIR /app

# Копіюємо package.json та package-lock.json. Шлях 'wwwroot' коректний,
# бо контекст збірки тепер - папка 'SkuffRoll/WebClient'.
COPY wwwroot/package*.json ./

# Встановлюємо залежності
RUN npm ci

# Копіюємо решту файлів фронтенду
COPY wwwroot/ ./

# Запускаємо скрипт збірки фронтенду
# Переконайтесь, що у вас є скрипт 'build' у package.json
RUN npm run build


# --- Етап 2: Збірка Бекенду (ASP.NET) ---
# Використовуємо офіційний образ .NET SDK.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-backend
WORKDIR /source

# Копіюємо файл проєкту. Шлях 'WebClient.csproj' коректний.
COPY WebClient.csproj .
RUN dotnet restore "WebClient.csproj"

# Копіюємо решту файлів проєкту з папки 'SkuffRoll/WebClient'
COPY . .

# Копіюємо зібрані файли фронтенду з попереднього етапу
# УВАГА: Перевірте, куди збирається ваш фронтенд. Зазвичай це 'build' або 'dist'.
# Якщо ваш скрипт 'npm run build' створює папку 'dist', замініть '/app/build' на '/app/dist'.
COPY --from=build-frontend /app/build ./wwwroot 

# Публікуємо проєкт
RUN dotnet publish "WebClient.csproj" -c Release -o /app/publish --no-restore


# --- Етап 3: Фінальний образ для запуску ---
# Використовуємо легкий образ ASP.NET Runtime.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Копіюємо скомпільований проєкт
COPY --from=build-backend /app/publish .

# Вказуємо порт, який слухає додаток (для .NET 8 за замовчуванням 8080)
EXPOSE 8080

# Точка входу для запуску додатку
ENTRYPOINT ["dotnet", "WebClient.dll"]