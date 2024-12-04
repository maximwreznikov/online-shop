FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Catalog.Api/Catalog.Api.csproj", "Catalog.Api/"]
COPY Catalog.Api/*.csproj Catalog.Api/
COPY Catalog.App/*.csproj Catalog.App/
COPY Catalog.Domain/*.csproj Catalog.Domain/
COPY Catalog.DAL/*.csproj Catalog.DAL/
COPY Cart.Contracts/*.csproj Cart.Contracts/
RUN dotnet restore "Catalog.Api/Catalog.Api.csproj"
COPY Catalog.Api/ Catalog.Api/
COPY Catalog.App/ Catalog.App/
COPY Catalog.Domain/ Catalog.Domain/
COPY Catalog.DAL/ Catalog.DAL/
COPY Cart.Contracts/ Cart.Contracts/
WORKDIR "/src/Catalog.Api"
RUN dotnet build "Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
RUN touch sql_main.db
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.Api.dll"]
