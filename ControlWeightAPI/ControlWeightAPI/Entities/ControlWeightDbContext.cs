using Microsoft.EntityFrameworkCore;

namespace ControlWeightAPI.Entities
{
    //Class represents connections with database and extra properties
    public class ControlWeightDbContext : DbContext
    {
        //SET YOUR SERVER AND DATABASE NAME
        private string _connectionString =
            "Server=YourServerName;Database=YourDatabaseName;Trusted_Connection=True;Trust Server Certificate=True";
        public DbSet<Measure> Measures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
