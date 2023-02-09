FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY Boilerplate.SignalR.Client/*.csproj Boilerplate.SignalR.Client/
RUN dotnet restore Boilerplate.SignalR.Client/Boilerplate.SignalR.Client.csproj

COPY Boilerplate.SignalR.Client/ Boilerplate.SignalR.Client/
WORKDIR /src/Boilerplate.SignalR.Client
RUN dotnet build -c Release --no-restore

FROM build AS publish
RUN dotnet publish -c Release --no-build -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Boilerplate.SignalR.Client.dll"]