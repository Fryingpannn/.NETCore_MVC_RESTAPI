# CLI Commands REST API (ASP.NET Core MVC)
#### With the plethora of CLI commands to learn, it is helpful to have an API which returns us commands that we often forget. This Commands API stores command line snippets along with a short description of what it does, as well as which platform it's for.
### The purpose of this project is to learn and practice concepts related to:
> - Building a REST API (routing, http, etc.) 
> - .NET Core
> - MVC Architectural Pattern
> - C#

#### More specifically, I familiarized myself with the following:
> - Dependency injection
> - Repository design pattern
> - SQL Server Express & SSMS
> - Entity Framework Core O/RM (DBContext, Migration)
> - Data Transfer Objects (DTOs) & AutoMapper
> - RESTful API guidelines
> - HTTP (GET, POST, PUT, PATCH, DELETE, status codes)
> - Other: Views (Razor, Shared Layout, ViewBag, RenderSection)

*Note: Please excuse the large amount of comments in my code which I used for notes and later review as this is my first time using the .NET Core framework.*

### Application Architecture:

![image](https://user-images.githubusercontent.com/59063950/91676248-3553ad80-eb0d-11ea-8fc7-e674ef0784a4.png)

### API Endpoints (CRUD):

![image](https://user-images.githubusercontent.com/59063950/91676062-8e6f1180-eb0c-11ea-83b0-affd0f607eac.png)

## Sample endpoints using Postman:

### [HttpPost] Creates a new command, returns Location header with link to resource, as well as the '201 Created' status code.

![image](https://user-images.githubusercontent.com/59063950/91677362-73060580-eb10-11ea-8097-6751b4c014d3.png)

### [HttpPatch] Updates the value of the howTo attribute and returns the '204 No Content' status code.

![image](https://user-images.githubusercontent.com/59063950/91677120-d17eb400-eb0f-11ea-84ea-8922972542fd.png)


