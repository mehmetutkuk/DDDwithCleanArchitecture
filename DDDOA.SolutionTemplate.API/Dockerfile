#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DDDOA.SolutionTemplate.API/DDDOA.SolutionTemplate.API.csproj", "DDDOA.SolutionTemplate.API/"]
COPY ["DDDOA.SolutionTemplate.Contracts/DDDOA.SolutionTemplate.Contracts.csproj", "DDDOA.SolutionTemplate.Contracts/"]
COPY ["DDDOA.SolutionTemplate.Application/DDDOA.SolutionTemplate.Application.csproj", "DDDOA.SolutionTemplate.Application/"]
COPY ["DDDOA.SolutionTemplate.Domain/DDDOA.SolutionTemplate.Domain.csproj", "DDDOA.SolutionTemplate.Domain/"]
COPY ["DDDOA.SolutionTemplate.Insfrastructure/DDDOA.SolutionTemplate.Insfrastructure.csproj", "DDDOA.SolutionTemplate.Insfrastructure/"]
RUN dotnet restore "DDDOA.SolutionTemplate.API/DDDOA.SolutionTemplate.API.csproj"
COPY . .
WORKDIR "/src/DDDOA.SolutionTemplate.API"
RUN dotnet build "DDDOA.SolutionTemplate.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DDDOA.SolutionTemplate.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DDDOA.SolutionTemplate.API.dll"]
