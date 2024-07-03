FROM nginx AS base

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
EXPOSE 8080

COPY ["Notifications.Client/Notifications.Client.csproj", "Notifications.Client/"]
RUN dotnet restore "./Notifications.Client/./Notifications.Client.csproj"
COPY . .
RUN dotnet build Notifications.Client/Notifications.Client.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Notifications.Client/Notifications.Client.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY Notifications.Client/nginx.conf /etc/nginx/nginx.conf