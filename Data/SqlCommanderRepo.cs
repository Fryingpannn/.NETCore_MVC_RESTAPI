using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

//Real repo

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        //instance of DB context class
        private CommanderContext _context;

        //Constructor injection: our dependency injection system will populate this 'context' variable with db data
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
        
        //adds a command obj to our _context db, saving is needed afterwards
        public void CreateCommand(Command cmd)
        {
            if(cmd == null){
                throw new ArgumentNullException(nameof(cmd));
            }
            
            _context.Commands.Add(cmd);
        }

        //every time you make change via dbcontext, the data won't be changed in db unless you use SaveChanges()
        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0 );
        }

        //PUT endpoint
        public void UpdateCommand(Command cmd)
        {
            //Nothing!
        }

        //DELETE endpoint (no need DTO)
        public void DeleteCommand(Command cmd)
        {
            if(cmd == null){
                throw new ArgumentNullException(nameof(cmd));
            }
            
            //remove selected command model
            _context.Commands.Remove(cmd);
        }
    }
}