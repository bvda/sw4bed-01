FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HelloCompose.API/HelloCompose.API.csproj", "./HelloCompose.API/"]
COPY ["HelloCompose.Data/HelloCompose.Data.csproj", "./HelloCompose.Data/"]
COPY ["HelloCompose.sln", "./"]
RUN dotnet restore
COPY . .
WORKDIR /src/HelloCompose.API
RUN dotnet build -c Release -o /app/build

FROM build as publish
RUN dotnet publish -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloCompose.API.dll"]