FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY Cart.Api/*.csproj Cart.Api/
COPY Cart.Core/*.csproj Cart.Core/
COPY Cart.DAL/*.csproj Cart.DAL/
COPY Cart.Queue/*.csproj Cart.Queue/
COPY Cart.Contracts/*.csproj Cart.Contracts/
RUN dotnet restore "Cart.Api/Cart.Api.csproj"
COPY Cart.Api/ Cart.Api/
COPY Cart.Core/ Cart.Core/
COPY Cart.DAL/ Cart.DAL/
COPY Cart.Queue/ Cart.Queue/
COPY Cart.Contracts/ Cart.Contracts/
WORKDIR "/src/Cart.Api"
RUN dotnet build "Cart.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Cart.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cart.Api.dll"]
