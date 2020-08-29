using Commander.Models;
using Microsoft.EntityFrameworkCore; //import EF to use ORM methods

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        //uses a constructor initializer, calls the base class constructor with parameter.
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt) 
        {
            
        }

        //Creating a command model in our DB: we want to represent our Command object down to our DB as a DbSet called Commands
        //Does the mapping for our Command mode; if more models, need more properties.
        public DbSet<Command> Commands { get; set; } //Commands will be the name of table in migration
    }
}