FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Rent.API/Rent.API.csproj", "Rent.API/"]
RUN dotnet restore "Rent.API/Rent.API.csproj"
COPY . .
WORKDIR "/src/Rent.API"
RUN dotnet build "Rent.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rent.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rent.API.dll"]
