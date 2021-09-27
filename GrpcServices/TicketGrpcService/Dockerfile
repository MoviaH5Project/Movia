FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ./GrpcServices/TicketGrpcService/TicketGrpcService.csproj ./GrpcServices/TicketGrpcService/
RUN dotnet restore ./GrpcServices/TicketGrpcService/TicketGrpcService.csproj

COPY ./Protos/TicketGrpcService.proto ./Protos/

COPY ./GrpcServices/TicketGrpcService/ ./GrpcServices/TicketGrpcService/
WORKDIR /src/
RUN dotnet build ./GrpcServices/TicketGrpcService/TicketGrpcService.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish ./GrpcServices/TicketGrpcService/TicketGrpcService.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketGrpcService.dll"]