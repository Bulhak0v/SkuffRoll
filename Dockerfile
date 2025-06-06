FROM node:20-alpine AS build-frontend
WORKDIR /app

COPY WebClient/WebClient/wwwroot/package*.json ./
RUN npm ci

COPY WebClient/WebClient/wwwroot/ ./
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-backend
WORKDIR /source

COPY WebClient/WebClient/WebClient.csproj ./
RUN dotnet restore "WebClient.csproj"

COPY WebClient/WebClient/ .
COPY --from=build-frontend /app/build/ ./wwwroot

RUN dotnet publish "WebClient.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-backend /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "WebClient.dll"]