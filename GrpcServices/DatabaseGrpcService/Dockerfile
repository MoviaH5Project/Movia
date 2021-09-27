FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./GrpcServices/DatabaseGrpcService/DatabaseGrpcService.csproj ./GrpcServices/DatabaseGrpcService/
RUN dotnet restore ./GrpcServices/DatabaseGrpcService/DatabaseGrpcService.csproj

COPY ./Protos/DatabaseGrpcService.proto ./Protos/

COPY ./GrpcServices/DatabaseGrpcService/ ./GrpcServices/DatabaseGrpcService/
WORKDIR /src/
RUN dotnet build ./GrpcServices/DatabaseGrpcService/DatabaseGrpcService.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ./GrpcServices/DatabaseGrpcService/DatabaseGrpcService.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DatabaseGrpcService.dll"]