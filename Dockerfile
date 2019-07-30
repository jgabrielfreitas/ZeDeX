FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY Zedex/*.csproj ./ZeDeX/
COPY ZeDeX.AppService/*.csproj ./ZeDeX.AppService/
COPY ZeDeX.Domain/*.csproj ./ZeDeX.Domain/
COPY ZeDeX.Infrastructure/*.csproj ./ZeDeX.Infrastructure/

RUN dotnet restore

# Copy everything else and build
COPY . ./

WORKDIR /app/Zedex
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/Zedex/out .

ENV ASPNETCORE_URLS=http://+:39500

ENTRYPOINT ["dotnet", "ZeDeX.dll"]
