# .NET containerization with Docker
## Assignment 1
The local bakery (the customer) wants to have a presence on the web. They have provided the SW4BED Developer Team (you) with a code base for which they need help to deploy to their cloud infrastructure.

The customer needs help writing the Dockerfiles needed to create Docker images for the two solutions: `bakery-api.sln` and `bakery-web.sln`.
### 1.1 Dockerfiles
1. Write a Dockerfile named `Dockerfile.API` that creates an image for `bakery-api.sln`
2. Write a Dockerfile named `Dockerfile.WEB` that creates and image for `bakery-web.sln` 

### 1.2 Docker Compose
1. Write a Docker Compose file that 

### 1.3 Push images to Docker Hub
Publish your images to Docker Hub[^1]

1. Push the image built in `1.1.1` to Docker Hub
2. Push the image built in `1.1.2` to Docker Hub

## Useful commands
- Build and tag a docker image with `docker build -t <IMAGE_TAG> -f <PATH_DOCKERFILE> <CONTEXT>`

## Resources
- https://docs.docker.com/engine/reference/commandline/build/
- [^1]: [Docker Hub Quickstart | Docker Documentation](https://docs.docker.com/docker-hub/)