using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

//Decoupling: We use this controller to access the repository's implemented class. Then that class accesses the database.

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
        //AutoMapper instance
        private readonly IMapper _mapper;

        //Constructor: dependency is injected into 'repository' variable
        //Also: injects an instance of AutoMapper object
        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /* MOCK REPO VARIABLE
        private readonly MockCommanderRepo _repository = new MockCommanderRepo(); //--> We don't need this anymore since we have the constructor (DI)
        */
        
        //This action will respond to GET api/commands
        //deciding that this method will respond to GET method
        [HttpGet]
        //create first action result endpoint
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            //return HTTP 200 OK result + commandItems
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));  //will map commandItem to the DTO instance
        }

        //putting {id} gives us a route to this action result, respond to: "GET api/commands/5"
        [HttpGet("{id}")] //since this one and above both respond to GET (same verb), their URI must be differentiated
        public ActionResult <CommandReadDto> GetCommandById(int id) //This 'id' comes from the request we pass via the URI (postman)
        {                                           //Model Binding: because we set [ApiController]: using default behaviour, id will come from [FromBody]
            var commandItem = _repository.GetCommandById(id);

            if(commandItem != null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            else
                return NotFound();  //if id doesn't exist, will indicate not found
        }
    }
}