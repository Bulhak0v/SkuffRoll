# --- Етап 1: Збірка Фронтенду (Node.js) ---
FROM node:20-alpine AS build-frontend
WORKDIR /app

# ==================== DEBUGGING ====================
# Показуємо, що знаходиться в корені контейнера до копіювання
RUN echo "--- Root directory listing in build-frontend stage ---" && ls -R /
# Показуємо, що знаходиться в робочій директорії /app (зараз вона порожня)
RUN echo "--- Workdir /app listing before copy ---" && ls -R .
# ===================================================

# Копіюємо package.json та package-lock.json для кешування залежностей
COPY wwwroot/package*.json ./

# Встановлюємо залежності. 'npm ci' швидше та надійніше для CI/CD,
# оскільки використовує package-lock.json.
RUN npm ci

# Копіюємо решту файлів фронтенду
COPY wwwroot/ ./

# ... (решта файлу без змін)


# --- Етап 2: Збірка Бекенду (ASP.NET) ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-backend
WORKDIR /source

# ==================== DEBUGGING ====================
# Показуємо вміст, який був скопійований з Git-репозиторію
RUN echo "--- Listing build context in build-backend stage ---" && ls -R .
# ===================================================

# Копіюємо файл проєкту для відновлення NuGet пакетів (кешування)
# Цей рядок, ймовірно, впаде, і лог вище покаже чому
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