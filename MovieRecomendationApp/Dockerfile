FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["MovieRecomendationApp.csproj", "MovieRecomendationApp/"]

RUN dotnet restore "MovieRecomendationApp/MovieRecomendationApp.csproj"
WORKDIR "/src/MovieRecomendationApp"
COPY . .
RUN dotnet build "MovieRecomendationApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MovieRecomendationApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MovieRecomendationApp.dll"]
