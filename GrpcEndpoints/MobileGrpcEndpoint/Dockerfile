FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./GrpcEndpoints/MobileGrpcEndpoint/MobileGrpcEndpoint.csproj ./GrpcEndpoints/MobileGrpcEndpoint/
RUN dotnet restore ./GrpcEndpoints/MobileGrpcEndpoint/MobileGrpcEndpoint.csproj

COPY ./Protos/BusGrpcService.proto ./Protos/
COPY ./Protos/TicketGrpcService.proto ./Protos/
COPY ./Protos/RouteGrpcService.proto ./Protos/
COPY ./Protos/MobileGrpcEndpoint.proto ./Protos/

COPY ./GrpcEndpoints/MobileGrpcEndpoint/ ./GrpcEndpoints/MobileGrpcEndpoint/
WORKDIR /src/
RUN dotnet build ./GrpcEndpoints/MobileGrpcEndpoint/MobileGrpcEndpoint.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ./GrpcEndpoints/MobileGrpcEndpoint/MobileGrpcEndpoint.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MobileGrpcEndpoint.dll"]
