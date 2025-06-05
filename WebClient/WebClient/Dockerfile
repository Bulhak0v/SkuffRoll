# Вказуємо базовий образ SDK для збірки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Встановлюємо робочий каталог всередині контейнера
WORKDIR /app

# Копіюємо csproj і solution файл у контейнер
COPY WebClient/WebClient.csproj ./WebClient.csproj
COPY WebClient/WebClient.sln ./WebClient.sln

# Відновлюємо залежності
RUN dotnet restore WebClient.csproj

# Копіюємо весь код у контейнер (враховуючи шлях)
COPY WebClient/. ./ 

# Збираємо проєкт
RUN dotnet publish WebClient.csproj -c Release -o out

# Створюємо runtime образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "WebClient.dll"]
