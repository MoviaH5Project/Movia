FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./GrpcEndpoints/WebsiteGrpcEndpoint/WebsiteGrpcEndpoint.csproj ./GrpcEndpoints/WebsiteGrpcEndpoint/
RUN dotnet restore ./GrpcEndpoints/WebsiteGrpcEndpoint/WebsiteGrpcEndpoint.csproj

COPY ./Protos/BusGrpcService.proto ./Protos/
COPY ./Protos/RouteGrpcService.proto ./Protos/
COPY ./Protos/WebsiteGrpcEndpoint.proto ./Protos/

COPY ./GrpcEndpoints/WebsiteGrpcEndpoint/ ./GrpcEndpoints/WebsiteGrpcEndpoint/
WORKDIR /src/
RUN dotnet build ./GrpcEndpoints/WebsiteGrpcEndpoint/WebsiteGrpcEndpoint.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ./GrpcEndpoints/WebsiteGrpcEndpoint/WebsiteGrpcEndpoint.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebsiteGrpcEndpoint.dll"]