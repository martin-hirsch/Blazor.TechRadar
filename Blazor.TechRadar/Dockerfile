FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Blazor.TechRadar/Blazor.TechRadar.csproj", "Blazor.TechRadar/"]

RUN dotnet restore "Blazor.TechRadar/Blazor.TechRadar.csproj"
COPY . .
WORKDIR "/src/Blazor.TechRadar"
RUN dotnet build "Blazor.TechRadar.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Blazor.TechRadar.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM nginx:alpine AS final
USER $APP_UID
WORKDIR /var/www/web

COPY --from=publish /app/publish/wwwroot .
COPY Blazor.TechRadar/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
EXPOSE 443