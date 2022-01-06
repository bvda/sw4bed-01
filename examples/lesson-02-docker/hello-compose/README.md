# HelloCompose

## Introduction
This repository contains a setup where a ASP.NET Core application uses Entity Framework Core to access a Microsoft SQL Server 2019 database with Docker Compose.

All commands in this README should be run for the soultion root directory (`examples/lesson-02-docker/hello-compose`).

This solution is based on the following offical Docker images published by Microsoft:
- [.NET SDK by Microsoft | Docker Hub](https://hub.docker.com/_/microsoft-dotnet-sdk/)
- [ASP.NET Core Runtime by Microsoft | Docker Hub](https://hub.docker.com/_/microsoft-dotnet-aspnet)
- [Microsoft SQL Server by Microsoft | Docker Hub](https://hub.docker.com/_/microsoft-mssql-server)


The solution follows the guidelines found in [Using a Separate Migrations Project - EF Core | Microsoft Docs](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli). It contains the followiing projects:
- `HelloCompose.API` – Application code
- `HelloCompose.Data` – Models and database contexts
- `HelloCompose.Migrations` – Migration code

## Getting started
### Build the solution
Run `docker compose build .` to build the solution.

### Run the solution
Run to `docker compose up` start the solution.

This will create to containers `hello-compose-api-1` and `hello-compose-db-1`. When starting the container for the first time, it will also create volume `hello-compose-db` where data are persisted between starts.

Run `dotnet ef database update --startup-project HelloCompose.API` to create the database in `hello-compose-db-1`. Make sure the the connection string are configured before running this command (see `examples/lesson-02-docker/hello-compose/HelloCompose.API/<appsettings|appsettings.Development>.json`)

## Migrations
### Run migrations

Add new migration with `dotnet ef migrations add <NAME> -p HelloCompose.Migrations -s HelloCompose.API`. 
- `-p|--project <PROJECT>` – relative path of the target project. Default value is current directory
- `-s|--startup-project <PROJECT>` – relative path of the startup-project. Default value is current directory

See [Migrations Overview - EF Core | Microsoft Docs](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) for more information.