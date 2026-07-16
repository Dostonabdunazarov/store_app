# Многостадийная сборка .NET 10 API (модульный монолит Hypex).
# Публикуемый проект — src/Hypex.Api; он тянет Application/Domain/Infrastructure.
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore src/Hypex.Api/Hypex.Api.csproj
RUN dotnet publish src/Hypex.Api/Hypex.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Hypex.Api.dll"]
