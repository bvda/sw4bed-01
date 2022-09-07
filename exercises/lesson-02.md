# Lesson 02 exercises
## Docker

## Exercise 02-1
### Install Docker on your machine
#### macOS 
Installing Docker on a macOS system should straightforward, just follow https://docs.docker.com/desktop/mac/install/ and you should be up and running in no time.

However, if you are sporting an Apple Chip, be sure to get correct version of Docker Desktop.

#### Linux
Running Linux? Then you are a bit on your own. Check out https://docs.docker.com/engine/install/ and find the installation instructions for your distribution.

#### Windows
If you are running Windows, we recommend using Windows Subsystem for Linux (WSL). Check out the guide @ https://docs.docker.com/desktop/windows/wsl/ for more information. Select one of the Debian-based distributions (we recommend Ubuntu).

You can get more information about WSL @ https://docs.microsoft.com/en-us/windows/wsl/about.

If you are running a Home edition of Windows 10/11, check out the blog post @ https://www.docker.com/blog/docker-desktop-for-windows-home-is-here/ on how to get up and running.

> :warning: WARNING: **Be sure to download and install WSL 2** If you are curious about the difference, check out https://docs.microsoft.com/en-us/windows/wsl/compare-versions.

## Exercise 02-2
### Containerizing a ASP.NET Core application
Go ahead and study the guide @ https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images (Make sure that you run the application using Linux containers)

Write down an answer to the following questions:
- Is it possible to have multiple Dockerfiles in one project?
- What are the benefits of using a multi-stage build strategy when building .NET images?

## Exercise 02-3
### Multi-container applications with Docker Compose
We have now created our first image and instantiated a container based on that image. The next step is to create a Compose file, so our peers can spin up our application in a breeze.

Create a `docker-compose.yaml` in the project root directory and add the following configuration:
- A service called `aspnetapp`
- Configure port 80 in the container to be exposed on 5000 on the host machine

Then go ahead and build the stack with `docker compose build`<sup>(<a href="https://docs.docker.com/engine/reference/commandline/compose_build/">docs</a>)</sup> and boot it up with `docker compose up`<sup>(<a href="https://docs.docker.com/engine/reference/commandline/compose_up/">docs</a>)</sup>

After verifying that everything is up and running, add a volume that maps to `/tmp` and a bind mount that maps to a folder on your host machine.  