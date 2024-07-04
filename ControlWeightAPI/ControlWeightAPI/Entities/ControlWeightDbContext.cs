using Microsoft.EntityFrameworkCore;

namespace ControlWeightAPI.Entities
{
    //Class represents connections with database and extra properties
    public class ControlWeightDbContext : DbContext
    {
        private string _connectionString =
            "Server=LAPTOP-3453MSLP;Database=ControlWeightDB;Trusted_Connection=True;Trust Server Certificate=True";
        public DbSet<Measure> Measures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
