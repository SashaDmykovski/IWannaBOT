FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["IWannaBOT/IWannaBOT.csproj", "./"]
RUN dotnet restore "./IWannaBOT.csproj"

COPY IWannaBOT/. .
RUN dotnet publish "./IWannaBOT.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IWannaBOT.dll"]
