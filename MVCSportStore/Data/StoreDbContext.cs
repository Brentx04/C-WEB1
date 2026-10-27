using Microsoft.EntityFrameworkCore;
using MVCSportStore.Models;

namespace MVCSportStore.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;

        // C# Web 16 - TagHelper (Table Reference Keys)
        public DbSet<Land> Landen { get; set; } = null!;
        public DbSet<Locatie> Locaties { get; set; } = null!;
        public DbSet<Afdeling> Afdelingen { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Startdata (komt mee in de migration -> Update-Database)
            modelBuilder.Entity<Land>().HasData(
                new Land { LandId = 1, LandCode = "BE", LandNaam = "België" },
                new Land { LandId = 2, LandCode = "NL", LandNaam = "Nederland" });

            modelBuilder.Entity<Locatie>().HasData(
                new Locatie { LocatieId = 1, Stad = "Brussel", LandId = 1 },
                new Locatie { LocatieId = 2, Stad = "Hasselt", LandId = 1 },
                new Locatie { LocatieId = 3, Stad = "AmsterDam", LandId = 2 });

            modelBuilder.Entity<Afdeling>().HasData(
                new Afdeling { AfdelingId = 1, AfdelingNaam = "Aankoop", LocatieId = 1 },
                new Afdeling { AfdelingId = 2, AfdelingNaam = "Verkoop", LocatieId = 2 },
                new Afdeling { AfdelingId = 3, AfdelingNaam = "Onderzoek", LocatieId = 3 });
        }
    }
}
