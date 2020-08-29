using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        //uses a constructor initializer, calls the base class constructor with parameter.
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt) 
        {
            
        }
    }
}