using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

//Decoupling: We use this controller to access the repository's implemented class. Then that class accesses the database.

namespace Commander.Controllers
{
    //The [] are attributes: declarative tags to give runtime info for the whole class
    //controller level route (base route): how you get to resources/api endpoints
    //Route(".."): matches URI to an action -->  will use the routing path from actions
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
        [SwaggerOperation(Summary = "Get all commands.")] //description on swagger UI
        [HttpGet]
        //create first action result endpoint
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            //return HTTP 200 OK result + commandItems
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));  //will map commandItem to the DTO instance
        }

        [SwaggerOperation(Summary = "Get the command of the given id number.")]
        //putting {id} gives us a route to this action result, respond to: "GET api/commands/5"
        [HttpGet("{id}", Name="GetCommandById")] //since this one and above both respond to GET (same verb), their URI must be differentiated
        public ActionResult <CommandReadDto> GetCommandById(int id) //This 'id' comes from the request we pass via the URI (postman)
        {                                                           //Model Binding: because we set [ApiController]: using default behaviour, id will come from [FromBody]
            var commandItem = _repository.GetCommandById(id);

            if(commandItem != null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            else
                return NotFound();  //if id doesn't exist, will indicate not found
        }

        [SwaggerOperation(Summary = "Creating a command; please fill in the three attributes. 'howTo' is the command description, 'line' is the code of the command, and 'platform' is its application platform.")]
        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            //Source -> Target
            var commandModel = _mapper.Map<Command>(commandCreateDto); //mapping from commandCreateDto to Command obj; returns mapped obj
            _repository.CreateCommand(commandModel); //create the model in db context
            _repository.SaveChanges(); //save changes so that the object is created in actual db


            //return a read dto instead
            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            //should also be sending back URI + HTTP 201 (REST principle)
            return CreatedAtRoute(nameof(GetCommandById), new {id = commandReadDto.id}, commandReadDto);

            //return Ok(commandReadDto);  --> returns 200
        }

        [SwaggerOperation(Summary = "Replaces the command of the given id with a new command you specify.")]
        //PUT api/commands/{id}
        //Since we only return http 204, return type = ActionResult
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            //check if requested model exists
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            //maps the newly created model to the requested one from repo --> updates dbcontext directly
            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            
            //still going to call the repo method although it's empty, some implementations may require it
            _repository.UpdateCommand(commandModelFromRepo);

            //flush changes to db
            _repository.SaveChanges();

            //return 204 No Content
            return NoContent();
        }

        [SwaggerOperation(Summary = "Use JSON 'replace' operation to perform a partial update on the given command. The 'value' is the new value you'd like, 'path' is either '/line' or '/howTo' (Delete 'from' and replace {} with \" \" for 'value').")]
        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            //check if requested model exists
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            //we are receiving the patchDoc from client, to apply the patch:

            //map repo model to dto
            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);

            //applying patch
            patchDoc.ApplyTo(commandToPatch, ModelState);

            //validation
            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            //maps the new patched dto model to the one in repo; updates dbcontext
            _mapper.Map(commandToPatch, commandModelFromRepo);

            //redundant empty update command
            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete the given command.")]
        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            //check if requested model exists
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            //deleting command model
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
