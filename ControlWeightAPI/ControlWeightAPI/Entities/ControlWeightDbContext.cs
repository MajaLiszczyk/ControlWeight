using Microsoft.EntityFrameworkCore;

namespace ControlWeightAPI.Entities
{
    //klasa zawierająca wlasciwosci odwzorowujace tabele w bazie danych
    // reprezentuje polaczenie do bazy danych poprzez entity framework
    // tej klasie można skonfigurować takie rzeczy, jak polaczenie do bazy danych, czy dodatkowe wlasciwosci, ktore powinny zawierac
    // kolumny bezposrednio w bazie danych, np. jakas kolumna wymagana
    public class ControlWeightDbContext : DbContext
    {
        private string _connectionString =
            "Server=LAPTOP-3453MSLP;Database=ControlWeightDB;Trusted_Connection=True;Trust Server Certificate=True";
            //"Server=(localdb)\\mssqllocaldb;Database=ControlWeightDB;Trusted_Connection=True;";
        public DbSet<Measure> Measures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
