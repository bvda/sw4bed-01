# Lesson 11 exercises
## Host Docker with HTTPS
First, we'll setup HTTPS[^1] with docker:
1. Create a new application with `dotnet new` or your favorite wizard in Visual Studio
2. Add a `Dockerfile` file to the project and add the necessary layers to create an image
3. Add a `docker-compose.yaml` file and configure the container[^2]
4. Add the following methods to a controller in your project
    ```cs
    [HttpPost]
    [Route("origin4200")]
    public IActionResult PostOrigin4200(Message message) {
        return new OkObjectResult(message);
    }

    [HttpPost]
    [Route("origin4300")]
    public IActionResult PostOrigin4300(Message message) {
        return new OkObjectResult(message);
    }

    [HttpPost]
    [Route("both")]
    public IActionResult Post(Message message) {
        return new OkObjectResult(message);
    }

    public class Message {
        public string Content { get; set; } = "";
    }
    ```
5. Check that everything looks good with Swagger and give them a spin in Postman

## Setup CORS for a specific origins
Next up, we have two new SPAs (written in Angular) that wants to communicate with our fresh API

1. Go to `exercises/lesson-11-improving-application-security/origin4300` and run `npm install` followed by `ng serve`
2. Open `http://localhost:4300/` in a browser of your choice to verify that everthing is working
3. Repeat steps 1 and 2 for `exercises/lesson-11-improving-application-security/origin4200`
4. Now we are ready to add CORS to our endpoint. We will be creating three different policies[^3] and apply them to each endpoint with attributes[^4].
    - An 'origin4200' policy that allows any headers, `POST` requests from origin `http://localhost:4200/`
    - An 'origin4300' policy that allows any headers, `POST` requests from origin `http://localhost:4300/` 
    - An 'both' policy that allows any headers, any method, and any origins

[^1]: https://docs.microsoft.com/en-us/aspnet/core/security/docker-https
[^2]: https://docs.microsoft.com/en-us/aspnet/core/security/docker-compose-https
[^3]: https://docs.microsoft.com/en-us/aspnet/core/security/cors#cors-policy-options
[^4]: https://docs.microsoft.com/en-us/aspnet/core/security/cors#enable-cors-with-attributes