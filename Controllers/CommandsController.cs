using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

//(?) Decoupling: We use this controller to reach in the repository's implemented class. Then that class accesses the database.

namespace Commander.Controllers
{
    //THESE [] ARE ATTRIBUTES: declarative tags to give info about runtime for the whole class
    //controller level route (base route): how you get to resources/api endpoints
    //Route(".."): MATCHES URI to an action -->  will pop the string from action in the api route. must change if class name changes.
    [Route("api/commands")] 
    [ApiController] //gives out of the box behaviours (makes life easier)
    public class CommandsController : ControllerBase //if inherit from controller, will bring view support (not needed)
    {
        //declaring interface repo
        //readonly = allows variable to be calculated at runtime | const = must have value at compile time
        //_ (underscore) indicates private (naming convention)
        private readonly ICommanderRepo _repository;

        //Constructor: dependency is injected into 'repository' variable
        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }

        /* MOCK REPO VARIABLE
        private readonly MockCommanderRepo _repository = new MockCommanderRepo(); //--> We don't need this anymore since we have the constructor (DI)
        */
        
        //This action will respond to GET api/commands
        //deciding that this method will respond to GET method
        [HttpGet]
        //create first action result endpoint
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();

            //return HTTP 200 OK result + commandItems
            return Ok(commandItems);
        }

        //putting {id} gives us a route to this action result, respond to: "GET api/commands/5"
        [HttpGet("{id}")] //since this one and above both respond to GET (same verb), their URI must be differentiated
        public ActionResult <Command> GetCommandById(int id) //This 'id' comes from the request we pass via the URI (postman)
        {                                           //Model Binding: because we set [ApiController]: using default behaviour, id will come from [FromBody]
            var commandItem = _repository.GetCommandById(id);

            return Ok(commandItem);
        }
    }
}