FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ZeDeX/ZeDeX.csproj", "ZeDeX/"]
COPY ["ZeDeX.AppService/ZeDeX.AppService.csproj", "ZeDeX.AppService/"]
COPY ["ZeDeX.Infrastructure/ZeDeX.Infrastructure.csproj", "ZeDeX.Infrastructure/"]
COPY ["ZeDeX.Domain/ZeDeX.Domain.csproj", "ZeDeX.Domain/"]
RUN dotnet restore "ZeDeX/ZeDeX.csproj"
COPY . .
WORKDIR "/src/ZeDeX"
RUN dotnet build "ZeDeX.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ZeDeX.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ZeDeX.dll"]