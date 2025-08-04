# Відповідна офіційна базова збірка для runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Збірка
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["IWannaBOT.csproj", "./"]
RUN dotnet restore "./IWannaBOT.csproj"
COPY . .
RUN dotnet build "IWannaBOT.csproj" -c Release -o /app/build

# Публікація
FROM build AS publish
RUN dotnet publish "IWannaBOT.csproj" -c Release -o /app/publish

# Фінальний образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IWannaBOT.dll"]
