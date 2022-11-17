# WebAPIConfiguration

- Generate migration with name `InitialCreate`: `dotnet ef migrations add 'InitialCreate' -- --environment Production`
- Update database: `dotnet ef database update -- --environment production`
- Run application with specific environment: `dotnet run --environment Production`

## Resources
https://developers.google.com/web/fundamentals/architecture/app-shell 