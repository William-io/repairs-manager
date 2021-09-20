#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Acquisition/Acquisition.API/Acquisition.API.csproj", "Services/Acquisition/Acquisition.API/"]
COPY ["Services/Acquisition/Acquisition.Infrastructure/Acquisition.Infrastructure.csproj", "Services/Acquisition/Acquisition.Infrastructure/"]
COPY ["Services/Acquisition/Acquisition.Domain/Acquisition.Domain.csproj", "Services/Acquisition/Acquisition.Domain/"]
RUN dotnet restore "Services/Acquisition/Acquisition.API/Acquisition.API.csproj"
COPY . .
WORKDIR "/src/Services/Acquisition/Acquisition.API"
RUN dotnet build "Acquisition.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Acquisition.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Acquisition.API.dll"]
