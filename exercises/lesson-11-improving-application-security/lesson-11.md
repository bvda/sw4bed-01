# Lesson 11 exercises
## Host Docker with HTTPS
When we publish our applications with Docker and inspect the container as it i

```
docker pull mcr.microsoft.com/dotnet/core/samples:aspnetapp
docker run --rm -it -p 5000:80 -p 5001:443 \
-e ASPNETCORE_URLS="https://+;http://+" \
-e ASPNETCORE_HTTPS_PORT=5001 \
-e ASPNETCORE_Kestrel__Certificates__Default__Password="secret" \
-e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx \
-v ~/.aspnet/https:/https/ mcr.microsoft.com/dotnet/core/samples:aspnetapp/
```