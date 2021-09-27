FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./GrpcServices/BusGrpcService/BusGrpcService.csproj ./GrpcServices/BusGrpcService/
RUN dotnet restore ./GrpcServices/BusGrpcService/BusGrpcService.csproj

COPY ./Protos/DatabaseGrpcService.proto ./Protos/
COPY ./Protos/BusGrpcService.proto ./Protos/

COPY ./GrpcServices/BusGrpcService/ ./GrpcServices/BusGrpcService/
WORKDIR /src/
RUN dotnet build ./GrpcServices/BusGrpcService/BusGrpcService.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ./GrpcServices/BusGrpcService/BusGrpcService.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BusGrpcService.dll"]