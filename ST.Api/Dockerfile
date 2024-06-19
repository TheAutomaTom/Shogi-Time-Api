#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 7281
EXPOSE 5028

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ST.Api/ST.Api.csproj", "ST.Api/"]
COPY ["ST.Core.Application/ST.Core.Application.csproj", "ST.Core.Application/"]
COPY ["ST.Core.Domain/ST.Core.Domain.csproj", "ST.Core.Domain/"]
COPY ["ST.Core.Infra/ST.Core.Infra.csproj", "ST.Core.Infra/"]
COPY ["ST.Data.Persistence/ST.Data.Persistence.csproj", "ST.Data.Persistence/"]
COPY ["ST.Data.Infra/ST.Data.Infra.csproj", "ST.Data.Infra/"]
RUN dotnet restore "./ST.Api/ST.Api.csproj"
COPY . .
WORKDIR "/src/ST.Api"
RUN dotnet build "./ST.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ST.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ST.Api.dll"]