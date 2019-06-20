FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src
COPY . .
COPY ParkingLot.App ParkingLot.App/
RUN dotnet restore
COPY . .

COPY ParkingLot.App.Test ParkingLot.App.Test/
RUN dotnet test

RUN dotnet publish ParkingLot.App/ParkingLot.App.csproj -c Release -o /app
FROM mcr.microsoft.com/dotnet/core/runtime:2.1 AS base

WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "ParkingLot.App.dll"]
