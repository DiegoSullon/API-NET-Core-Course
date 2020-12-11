# API-NET-Core-Course
## Dependencies(nuget gallery)
```
jwt
ef
ef in memory
ef relational
NewtonsoftJson
Microsoft.AspNetCore.Mvc.NewtonsoftJson 
ef design
dotnet ef migrations add InitialCreate
dotnet tool install --global dotnet-ef
ef sql server
dotnet ef database update
Swashbuckle.AspNetCore.Swagger 
odata.net core

```

## Publish

```
dotnet publish
dotnet publish -c release
dotnet publish -c release -r win-x64 --output ./../publish
dotnet publish -c release -r linux-x64 --output ./publish
```
## Docker
```
docker build -t webapi .
docker run -p 88:80 webapi
```
