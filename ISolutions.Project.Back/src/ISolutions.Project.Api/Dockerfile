#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ISolutions.Project.Back/src/ISolutions.Project.Api/ISolutions.Project.Api.csproj", "ISolutions.Project.Back/src/ISolutions.Project.Api/"]
COPY ["ISolutions.Project.Back/src/ISolutions.Project.Application/ISolutions.Project.Application.csproj", "ISolutions.Project.Back/src/ISolutions.Project.Application/"]
COPY ["ISolutions.Project.Back/src/ISolutions.Project.Domain/ISolutions.Project.Domain.csproj", "ISolutions.Project.Back/src/ISolutions.Project.Domain/"]
COPY ["ISolutions.Project.Back/src/ISolutions.Project.Infrastructure/ISolutions.Project.Infrastructure.csproj", "ISolutions.Project.Back/src/ISolutions.Project.Infrastructure/"]
RUN dotnet restore "./ISolutions.Project.Back/src/ISolutions.Project.Api/ISolutions.Project.Api.csproj"
COPY . .
WORKDIR "/src/ISolutions.Project.Back/src/ISolutions.Project.Api"
RUN dotnet build "./ISolutions.Project.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ISolutions.Project.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ISolutions.Project.Api.dll"]