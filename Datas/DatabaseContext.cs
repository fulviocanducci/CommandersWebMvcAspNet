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
        }
    }
}