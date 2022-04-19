# Lesson 11 exercises
## Host Docker with HTTPS
First, we'll setup HTTPS[^1] with docker:
1. Create a new application with `dotnet new` or your favorite wizard in Visual Studio
2. Add a `Dockerfile` file to the project and add the necessary layers to create an image
3. Add a `docker-compose.yaml` file and configure the container[^2]

You can checkout `examples/lesson-11-improving-application-security/CrossSiteScripting/docker-compose.yaml` if you need some inspiration or want to try it out for yourself

## Setup CORS for a specific origins
Next up, we have two new SPAs (written in Angular) that wants to communicate with our   

[^1]: https://docs.microsoft.com/en-us/aspnet/core/security/docker-https
[^2]: https://docs.microsoft.com/en-us/aspnet/core/security/docker-compose-https