using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class ClupContext : DbContext
    {
        public ClupContext(DbContextOptions<ClupContext>dbContextoptions) : base(dbContextoptions)
        {
          
        }

        public DbSet<Clup> Clups { get; set; }

        public DbSet<Leauge> Lauges { get; set; }

        public DbSet<Player> Players { get; set; }
    
    }
}
