#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Rent.API/Rent.API.csproj", "Rent.API/"]
COPY ["Rent.BL/Rent.BL.csproj", "Rent.BL/"]
COPY ["Rent.DAL/Rent.DAL.csproj", "Rent.DAL/"]
COPY ["Rent.Domain/Rent.Domain.csproj", "Rent.Domain/"]
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