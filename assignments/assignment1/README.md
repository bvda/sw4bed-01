# .NET containerization with Docker
## Assignment 1
The local bakery (the customer) wants to have a presence on the web. They have provided the SW4BED Developer Team (you) with a code base for which they need help to deploy to their cloud infrastructure.

The customer needs help writing the Dockerfiles needed to create Docker images for the two solutions: `bakery-api.sln` and `bakery-web.sln` and a Docker Compose file that can help them distribute the application internally.

### 1.1 Dockerfiles


1. Write a Dockerfile[^2] named `Dockerfile.API` that creates an image for `bakery-api.sln`
2. Write a Dockerfile named `Dockerfile.WEB` that creates and image for `bakery-web.sln` 

### 1.2 Docker Compose
1. Write a Docker Compose file that uses the two images with the following configuration:
    
    - Two services: A service named `api` for `bakery-api` and a service named `web` for `bakery-web`
    - Publish `bakery-api` on port `6000` on the host
    - Publish `bakery-web` on port `5000` on the host
    - `bakery-web` has an environment variable[^4] named `API_URL` that should contain an URL to the base address of the API service[^4]

### 1.3 Push images to Docker Hub
Publish your images to Docker Hub[^1]. 

1. Push the image built in `1.1.1` to Docker Hub
2. Push the image built in `1.1.2` to Docker Hub
3. If needed, update the images used in `docker-compose.yaml` in `1.2` so they match your published images.

[^1]: [Docker Hub Quickstart | Docker Documentation](https://docs.docker.com/docker-hub/)
[^2]: [Docker images for ASP.NET Core | Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-6.0)
[^3]: [Environment variables in Compose | Docker Documentation](https://docs.docker.com/compose/environment-variables/)
[^4]: [Networking in Compose | Docker Documentation](https://docs.docker.com/compose/networking/)