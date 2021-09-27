FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./GrpcServices/RouteGrpcService/RouteGrpcService.csproj ./GrpcServices/RouteGrpcService/
RUN dotnet restore ./GrpcServices/RouteGrpcService/RouteGrpcService.csproj

COPY ./Protos/RouteGrpcService.proto ./Protos/

COPY ./GrpcServices/RouteGrpcService/ ./GrpcServices/RouteGrpcService/
WORKDIR /src/
RUN dotnet build ./GrpcServices/RouteGrpcService/RouteGrpcService.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ./GrpcServices/RouteGrpcService/RouteGrpcService.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RouteGrpcService.dll"]