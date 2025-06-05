# Вказуємо базовий образ SDK для збірки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копіюємо всі файли проекту в робочу директорію
COPY . .

# Відновлюємо залежності (restore) для проекту у поточній папці
RUN dotnet restore "WebClient.csproj"

# Будуємо проект в релізній конфігурації
RUN dotnet publish "WebClient.csproj" -c Release -o /app/publish

# Вказуємо базовий образ ASP.NET Core для запуску
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Копіюємо збудовану апку з попереднього кроку
COPY --from=build /app/publish .

# Вказуємо команду запуску додатка
ENTRYPOINT ["dotnet", "WebClient.dll"]
