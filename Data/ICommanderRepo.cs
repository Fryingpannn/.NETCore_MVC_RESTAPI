using System.IO.MemoryMappedFiles;
using System.Reflection;
using System.Collections.Generic;
using Commander.Models;

//'Data' is our repository
namespace Commander.Data
{
    //Interface class.
    //Since we are building a CRUD app, our repository interface imitates the CRUD functionalities
    public interface ICommanderRepo
    {
        //every time you make change via dbcontext, the data won't be changed in db unless you use SaveChanges()
        bool SaveChanges();


        //Give list of all command objects/resources
        IEnumerable<Command> GetAllCommands();

        //Return single command depending on provided ID
        Command GetCommandById(int id);

        //Create Command object (POST)
        void CreateCommand(Command cmd);

        //PUT
        void UpdateCommand(Command cmd);

        //DELETE
        void DeleteCommand(Command cmd);
    }
}