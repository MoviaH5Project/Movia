FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./GrpcEndpoints/BusGrpcEndpoint/BusGrpcEndpoint.csproj ./GrpcEndpoints/BusGrpcEndpoint/
RUN dotnet restore ./GrpcEndpoints/BusGrpcEndpoint/BusGrpcEndpoint.csproj

COPY ./Protos/BusGrpcService.proto ./Protos/
COPY ./Protos/TicketGrpcService.proto ./Protos/
COPY ./Protos/BusGrpcEndpoint.proto ./Protos/

COPY ./GrpcEndpoints/BusGrpcEndpoint/ ./GrpcEndpoints/BusGrpcEndpoint/
WORKDIR /src/
RUN dotnet build ./GrpcEndpoints/BusGrpcEndpoint/BusGrpcEndpoint.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ./GrpcEndpoints/BusGrpcEndpoint/BusGrpcEndpoint.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BusGrpcEndpoint.dll"]