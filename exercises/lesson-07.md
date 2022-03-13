# Lesson 07 exercises
## Configuration in ASP.NET Core
The purpose of this exercise is to extract configuration from an existing app and apply the Options pattern[^1] to create strongly typed access for configuration.


## Exercise 07-1
1. Setup a Docker container running Microsoft SQL Server[^2] (get the image with `docker pull mcr.microsoft.com/mssql/server` if haven't got it already)
2. Choose a strong password and add that ti the environment variable `SA_PASSWORD`
3. Start the container with the following command: `docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD={VeryStrongPasswordHere!}" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest`

## Exercise 07-2


[^1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options
[^2]: https://hub.docker.com/_/microsoft-mssql-server