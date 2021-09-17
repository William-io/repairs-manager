#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Management/Management.API/Management.API.csproj", "Services/Management/Management.API/"]
COPY ["Services/Management/Management.Data/Management.Data.csproj", "Services/Management/Management.Data/"]
COPY ["Services/Management/Management.Domain/Management.Domain.csproj", "Services/Management/Management.Domain/"]
RUN dotnet restore "Services/Management/Management.API/Management.API.csproj"
COPY . .
WORKDIR "/src/Services/Management/Management.API"
RUN dotnet build "Management.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Management.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Management.API.dll"]
