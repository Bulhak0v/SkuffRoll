# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Копіюємо csproj та solution файли (вони у цій папці, бо контекст - WebClient\WebClient)
COPY WebClient.csproj .
COPY WebClient.sln .

# Відновлення залежностей
RUN dotnet restore WebClient.csproj

# Копіюємо увесь код проекту (усі файли і папки у цій теці)
COPY . .

# Збірка проєкту в Release
RUN dotnet publish -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Копіюємо результати збірки з попереднього етапу
COPY --from=build /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "WebClient.dll"]
