FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["whales.csproj", "./"]
COPY setup.sh setup.sh

RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "./whales.csproj"
COPY . .
WORKDIR "/src/."

RUN /root/.dotnet/tools/dotnet-ef migrations add InitialMigrations

RUN chmod +x ./setup.sh
CMD /bin/bash ./setup.sh