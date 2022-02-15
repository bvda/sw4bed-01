# .NET containerization with Docker
## Assignment 1

1. Create a solution with two projects `bakery-api` and `bakery-web` (check https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new)
2. Add a `Pastries` page and a `Bread` page (https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates#page) to `bakery-web`
  - `dotnet new page -n Pastries`
  - `dotnet new page -n Bread`
3. Add a `.gitignore` with `dotnet new gitignore` (make sure the current directory is where the solution file is located)

### useful commands
- Run application with `bakery-web` as startup project: `dotnet run --project bakery-web`