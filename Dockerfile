FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app
COPY . .
RUN dotnet restore . 
RUN dotnet build "./src/LanchoneteDaRua.Ms.Pedidos.Api/LanchoneteDaRua.Ms.Pedidos.Api.csproj" -c Release

FROM build AS publish
RUN dotnet publish "./src/LanchoneteDaRua.Ms.Pedidos.Api/LanchoneteDaRua.Ms.Pedidos.Api.csproj" -c Release -o /publish

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS production
ENV ASPNETCORE_ENVIRONMENT=Production
WORKDIR /app
COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "LanchoneteDaRua.Ms.Pedidos.Api.dll"]