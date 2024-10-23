
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia el archivo de proyecto y restaurar dependencias
COPY ["MarcasAutosAPI.csproj", "./"]
RUN dotnet restore

COPY . .
RUN dotnet build "MarcasAutosAPI.csproj" -c Release -o /app/build

# Publica la aplicación
RUN dotnet publish "MarcasAutosAPI.csproj" -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "MarcasAutosAPI.dll"]
