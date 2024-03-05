#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VehicleFees.Api/VehicleFees.Api.csproj", "VehicleFees.Api/"]
COPY ["VehicleFees.Application/VehicleFees.Application.csproj", "VehicleFees.Application/"]
COPY ["VehicleFees.Domain/VehicleFees.Domain.csproj", "VehicleFees.Domain/"]
COPY ["VehicleFees.Infrastructure/VehicleFees.Infrastructure.csproj", "VehicleFees.Infrastructure/"]
RUN dotnet restore "./VehicleFees.Api/./VehicleFees.Api.csproj"
COPY . .
WORKDIR "/src/VehicleFees.Api"
RUN dotnet build "./VehicleFees.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VehicleFees.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehicleFees.Api.dll"]