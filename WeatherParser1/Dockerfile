#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WeatherParser1/WeatherParser1.csproj", "WeatherParser1/"]
COPY ["WeatherParser1.App/WeatherParser1.App.csproj", "WeatherParser1.App/"]
RUN dotnet restore "WeatherParser1/WeatherParser1.csproj"
COPY . .
WORKDIR "/src/WeatherParser1"
RUN dotnet build "WeatherParser1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherParser1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherParser1.dll"]