#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EvCharging.API/EvCharging.API.csproj", "EvCharging.API/"]
COPY ["EvCharging.App/EvCharging.App.csproj", "EvCharging.App/"]
COPY ["EvCharging.Core/EvCharging.Core.csproj", "EvCharging.Core/"]
RUN dotnet restore "EvCharging.API/EvCharging.API.csproj"
COPY . .
WORKDIR "/src/EvCharging.API"
RUN dotnet build "EvCharging.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EvCharging.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EvCharging.API.dll"]