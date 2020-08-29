using System.IO.MemoryMappedFiles;
using System.Reflection;
using System.Collections.Generic;
using Commander.Models;

//Data = repository
namespace Commander.Data
{
    //Interface class.
    //Since we are building a CRUD app, our repository kind of imitates the CRUD functionalities
    public interface ICommanderRepo
    {
        //Give list of all command objects/resources
        IEnumerable<Command> GetAllCommands();

        //Return single command depending on provided ID
        Command GetCommandById(int id);
    }
}