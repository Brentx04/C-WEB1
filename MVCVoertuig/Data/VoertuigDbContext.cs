using Microsoft.EntityFrameworkCore;
using MVCVoertuig.Models;

namespace MVCVoertuig.Data
{
    // Stap 2 - DbContext: de "brug" tussen C# en de SQL Server databank
    public class VoertuigDbContext : DbContext
    {
        // De options (connection string, UseSqlServer) komen binnen via Program.cs
        public VoertuigDbContext(DbContextOptions<VoertuigDbContext> options) : base(options) { }

        // Stap 9 - Tabel "Voertuigen" gebaseerd op het model Voertuig
        public DbSet<Voertuig> Voertuigen { get; set; } = null!;
    }
}
