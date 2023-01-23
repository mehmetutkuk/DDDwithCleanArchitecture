#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Euronext.CompanyWebcast.API/Euronext.CompanyWebcast.API.csproj", "Euronext.CompanyWebcast.API/"]
COPY ["Euronext.CompanyWebcast.Contracts/Euronext.CompanyWebcast.Contracts.csproj", "Euronext.CompanyWebcast.Contracts/"]
COPY ["Euronext.CompanyWebcast.Application/Euronext.CompanyWebcast.Application.csproj", "Euronext.CompanyWebcast.Application/"]
COPY ["Euronext.CompanyWebcast.Domain/Euronext.CompanyWebcast.Domain.csproj", "Euronext.CompanyWebcast.Domain/"]
COPY ["Euronext.CompanyWebcast.Insfrastructure/Euronext.CompanyWebcast.Insfrastructure.csproj", "Euronext.CompanyWebcast.Insfrastructure/"]
RUN dotnet restore "Euronext.CompanyWebcast.API/Euronext.CompanyWebcast.API.csproj"
COPY . .
WORKDIR "/src/Euronext.CompanyWebcast.API"
RUN dotnet build "Euronext.CompanyWebcast.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Euronext.CompanyWebcast.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Euronext.CompanyWebcast.API.dll"]
