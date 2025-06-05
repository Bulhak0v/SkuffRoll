FROM node:20 AS builder

WORKDIR /WebClient
RUN ls -la /WebClient/wwwroot

COPY ./wwwroot ./wwwroot

RUN npm install

COPY wwwroot/ .

RUN npm run build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=builder /WebClient/build ./wwwroot/public/dist

ENTRYPOINT ["dotnet", "YourAppName.dll"]
