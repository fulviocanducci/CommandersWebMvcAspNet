using Commanders.Models;
using Commanders.Models.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Commanders.Datas
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommanderMapping());
            modelBuilder.ApplyConfiguration(new TodoMapping());
        }

        public DbSet<Commander> Commander {get;set;}
        public DbSet<Todo> Todo {get;set;}
    }
}