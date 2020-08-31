# CLI Commands REST API (ASP.NET Core MVC)
#### With the plethora of CLI commands to learn, it is helpful to have an API which returns us commands that we often forget. This Commands API stores command line snippets along with a short description of what it does, as well as which platform it's for.
### The purpose of this project is to learn and practice concepts related to:
> - Building a REST API (routing, http, etc.) 
> - .NET Core (C#, Dependency Injection, Entity Framework Core, Data Access (DB Context, Migration), SQL Server Express, Repositories, DTO)
> - MVC Architectural Pattern

*Note: Please excuse the large amount of comments in my code which I used to take notes and for later review as this is my first time using the .NET Core framework.*

### Application Architecture:

![image](https://user-images.githubusercontent.com/59063950/91676248-3553ad80-eb0d-11ea-8fc7-e674ef0784a4.png)

### API Endpoints:

![image](https://user-images.githubusercontent.com/59063950/91676062-8e6f1180-eb0c-11ea-83b0-affd0f607eac.png)

## Sample endpoints using Postman:

### [HttpPost] -> api/commands/: Creates a new command, returns Location header with link to resource, as well as 201 Created status code.

![image](https://user-images.githubusercontent.com/59063950/91677027-8a90be80-eb0f-11ea-991a-be1c7328e24d.png)

### [HttpPatch] -> api/commands/{id}: Modifies the 

![image](https://user-images.githubusercontent.com/59063950/91677120-d17eb400-eb0f-11ea-84ea-8922972542fd.png)


