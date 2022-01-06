# HelloCompose

## Introduction


## Getting started
### Build the solution
Run `docker compose build .` to build the solution.

### Run the solution
Run to `docker compose up` start the solution.

This will create to containers `hello-compose-api-1` and `hello-compose-db-1`. When starting the container for the first time, it will also create volume `hello-compose-db` where data are persisted between starts.

## Migrations
### Run migrations
Run `dotnet ef database update --startup-project HelloCompose.API` to create the database in `hello-compose-db-1`.

See [Migrations Overview - EF Core | Microsoft Docs](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) for more information.