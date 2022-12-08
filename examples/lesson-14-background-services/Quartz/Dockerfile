FROM mcr.microsoft.com/dotnet/aspnet:7.0 as base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Quartz.API/Quartz.API.csproj", "./Quartz.API/"]
COPY ["Quartz.Data/Quartz.Data.csproj", "./Quartz.Data/"]
COPY ["Quartz.Migration/Quartz.Migration.csproj", "./Quartz.Migration/"]
COPY ["Quartz.sln", "./"]
RUN dotnet restore
COPY . .
WORKDIR /src/Quartz.API
RUN dotnet build -c Release -o /app/build

FROM build as publish
RUN dotnet publish -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quartz.API.dll"]