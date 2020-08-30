using System.Collections.Generic;
using Commander.Models;

//MOCK REPOSITORY, NOT USED IN FINAL VERSION <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//Data = repository
namespace Commander.Data
{
    //Implementing ICommanderRepo interface, decoupling code!
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command> //implicit type
            { 
                //mock database data
                new Command{id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan"}, //curly brackets: object initializer
                new Command{id=0, HowTo="Cut Bread", Line="Get knife", Platform="Table"},
                new Command{id=0, HowTo="Make tea", Line="Place Teabag", Platform="Kettle cup"}
            };
            
            return commands;
        }

        public Command GetCommandById(int id)
        {
            //mock database data
            return new Command{id=id, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}