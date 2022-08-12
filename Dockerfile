#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY *.sln .

COPY ["TACShilohDistricts/TACShilohDistricts.csproj", "TACShilohDistricts/"]
COPY ["TACShilohDistricts.Application/TACShilohDistricts.Application.csproj", "TACShilohDistricts.Application/"]
COPY ["TACShilohDistricts.Core/TACShilohDistricts.Core.csproj", "TACShilohDistricts.Core/"]
COPY ["TACShilohDistricts.Infrastructure/TACShilohDistricts.Infrastructure.csproj", "TACShilohDistricts.Infrastructure/"]
COPY ["TACShilohDistricts.Services/TACShilohDistricts.Services.csproj", "TACShilohDistricts.Services/"]

RUN dotnet restore "TACShilohDistricts/TACShilohDistricts.csproj"
COPY . .

WORKDIR /src/TACShilohDistricts
RUN dotnet build

FROM build AS publish
WORKDIR /src/TACShilohDistricts
RUN dotnet publish -c Release -o /app/publish 


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:$PORT
ENTRYPOINT ["dotnet", "TACShilohDistricts.dll"]