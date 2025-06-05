# --- Етап 1: Збірка Фронтенду (Node.js) ---
# Використовуємо офіційний образ Node.js. 'alpine' - це легка версія Linux.
# Замініть '20' на вашу версію Node.js, якщо потрібно.
FROM node:20-alpine AS build-frontend
WORKDIR /app

# Копіюємо package.json та package-lock.json для кешування залежностей
COPY wwwroot/package*.json ./

# Встановлюємо залежності. 'npm ci' швидше та надійніше для CI/CD,
# оскільки використовує package-lock.json.
RUN npm ci

# Копіюємо решту файлів фронтенду
COPY wwwroot/ ./

# Запускаємо скрипт збірки фронтенду (зазвичай 'build' у package.json)
# Ця команда створить оптимізовані JS/CSS файли, зазвичай у папці 'dist' або 'build'.
RUN npm run build


# --- Етап 2: Збірка Бекенду (ASP.NET) ---
# Використовуємо офіційний образ .NET SDK.
# Замініть '8.0' на вашу версію .NET.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-backend
WORKDIR /source

# Копіюємо файл проєкту для відновлення NuGet пакетів (кешування)
COPY WebClient.csproj .
RUN dotnet restore "WebClient.csproj"

# Копіюємо решту файлів проєкту
COPY . .

# Копіюємо зібрані файли фронтенду з попереднього етапу
# ВАЖЛИВО: Шлях '/app/build' залежить від конфігурації вашого фронтенд-скрипта.
# Подивіться у вашому webpack.config.js або аналогічному файлі, куди відбувається збірка.
# Популярні варіанти: '/app/dist', '/app/build'.
# Ми копіюємо їх у wwwroot, звідки ASP.NET їх буде роздавати.
COPY --from=build-frontend /app/build ./wwwroot 

# Публікуємо проєкт у режимі Release.
# '--no-restore' використовується, бо ми вже відновили пакети.
RUN dotnet publish "WebClient.csproj" -c Release -o /app/publish --no-restore


# --- Етап 3: Фінальний образ для запуску ---
# Використовуємо легкий образ ASP.NET Runtime, він не містить SDK.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Копіюємо скомпільований проєкт з етапу збірки
COPY --from=build-backend /app/publish .

# Вказуємо порт, який слухає додаток (за замовчуванням 8080 для .NET 8)
EXPOSE 8080

# Точка входу для запуску додатку
ENTRYPOINT ["dotnet", "WebClient.dll"]