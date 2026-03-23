# Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar apenas os csproj (melhora cache)
COPY ["App/OrdemServico.Api/OrdemServico.Api.csproj", "App/OrdemServico.Api/"]
COPY ["Domain/OrdemServico.Domain/OrdemServico.Domain.csproj", "Domain/OrdemServico.Domain/"]
COPY ["Infra.Database/OrdemServico.Infra.Database/OrdemServico.Infra.Database.csproj", "Infra.Database/OrdemServico.Infra.Database/"]
COPY ["Service/OrdemServico.Service/OrdemServico.Service.csproj", "Service/OrdemServico.Service/"]

# Restore
RUN dotnet restore "App/OrdemServico.Api/OrdemServico.Api.csproj"

# Copiar tudo
COPY . .

# Build
WORKDIR "/src/App/OrdemServico.Api"
RUN dotnet build "OrdemServico.Api.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "OrdemServico.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "OrdemServico.Api.dll"]