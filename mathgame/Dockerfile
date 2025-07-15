# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia a solução e os arquivos de projeto
COPY . ./

# Restaura dependências
RUN dotnet restore

# Copia tudo
COPY . .

# Publica a aplicação
RUN dotnet publish -c Release -o /app/out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "mathgame.dll"]