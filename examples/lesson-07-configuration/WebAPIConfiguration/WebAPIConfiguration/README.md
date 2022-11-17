# WebAPIConfiguration

"Server=127.0.0.1,1433;Database=master;User=sa;Password=suchSecureVeryWordSoPassW0w!;"
- Generate migration with name `InitialCreate`: `dotnet ef migrations add 'InitialCreate' -- --environment Production`
- Update database: `dotnet ef database update --connection "Server=127.0.0.1,1433;Database=master;User=sa;Password=suchSecureVeryWordSoPassW0w!;" -- --environment production`
- Run application with specific environment: `dotnet run --environment Production`

## Resources
https://developers.google.com/web/fundamentals/architecture/app-shell 