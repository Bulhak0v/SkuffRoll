
FROM node:20 AS react-build
WORKDIR /app

COPY wwwroot/src ./src
COPY wwwroot/package.json .
COPY wwwroot/package-lock.json .

RUN npm install
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore

COPY . ./

COPY --from=react-build /app/build ./wwwroot

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://+:$PORT
EXPOSE 80
ENTRYPOINT ["dotnet", "WebClient.dll"]
