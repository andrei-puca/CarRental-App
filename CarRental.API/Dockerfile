#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CarRental.API/CarRental.API.csproj", "CarRental.API/"]
COPY ["CarRental.API.Common/CarRental.API.Common.csproj", "CarRental.API.Common/"]
COPY ["CarRental.API.BL/CarRental.API.BL.csproj", "CarRental.API.BL/"]
COPY ["CarRental.API.DAL/CarRental.API.DAL.csproj", "CarRental.API.DAL/"]
RUN dotnet restore "CarRental.API/CarRental.API.csproj"
COPY . .
WORKDIR "/src/CarRental.API"
RUN dotnet build "CarRental.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarRental.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarRental.API.dll"]