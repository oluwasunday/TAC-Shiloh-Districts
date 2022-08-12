FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5100

ENV ASPNETCORE_URLS=http://+:5100

# build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY *.sln .
COPY ["TACShilohDistricts/TACShilohDistricts.csproj", "TACShilohDistricts/"]
COPY ["TACShilohDistricts.Services/TACShilohDistricts.Services.csproj", "TACShilohDistricts.Services/"]
COPY ["TACShilohDistricts.Infrastructure/TACShilohDistricts.Infrastructure.csproj", "TACShilohDistricts.Infrastructure/"]
COPY ["TACShilohDistricts.Core/TACShilohDistricts.Core.csproj", "TACShilohDistricts.Core/"]
COPY ["TACShilohDistricts.Application/TACShilohDistricts.Application", "TACShilohDistricts.Application/"]

RUN dotnet restore "TACShilohDistricts\TACShilohDistricts.csproj"
COPY . .
WORKDIR "/src/TACShilohDistricts" 
#WORKDIR /src/TACShilohDistricts

RUN dotnet build "TACShilohDistricts.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/TACShilohDistricts"
RUN dotnet publish "TACShilohDistricts.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#ENTRYPOINT ["dotnet", "TACShilohDistricts.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet TACShilohDistricts.dll