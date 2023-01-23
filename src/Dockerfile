FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY Boilerplate.WebApi/*.csproj Boilerplate.WebApi/
COPY Boilerplate.Application/*.csproj Boilerplate.Application/
COPY Boilerplate.Infrastructure/*.csproj Boilerplate.Infrastructure/
COPY Boilerplate.Domain/*.csproj Boilerplate.Domain/
RUN dotnet restore Boilerplate.WebApi/Boilerplate.WebApi.csproj

COPY Boilerplate.WebApi/ Boilerplate.WebApi/
COPY Boilerplate.Application/ Boilerplate.Application/
COPY Boilerplate.Infrastructure/ Boilerplate.Infrastructure/
COPY Boilerplate.Domain/ Boilerplate.Domain/
WORKDIR /src/Boilerplate.WebApi
RUN dotnet build -c Release --no-restore

FROM build AS publish
RUN dotnet publish -c Release --no-build -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Boilerplate.WebApi.dll"]