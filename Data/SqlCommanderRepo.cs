using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        //instance of DB context class
        private CommanderContext _context;

        //our dependency injection system will populate this 'context' variable
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {

            return _context.Commands.ToList(); //returns a list of all commands from our DB
        }

        public Command GetCommandById(int id)
        {
            //FirstOrDefault = LINQ command
            return _context.Commands.FirstOrDefault(p => p.id == id); //returns first id that matches
        }
    }
}