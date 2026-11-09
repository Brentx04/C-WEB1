using MVCVoertuig.Models;

namespace MVCVoertuig.Data
{
    // Stap 10 - Default data: voertuigen toevoegen bij de opstart (enkel als de tabel leeg is)
    public static class SeedData
    {
        public static void EnsurePopulated(WebApplication app)
        {
            // DbContext is "scoped" -> we hebben een scope nodig om hem op te vragen
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<VoertuigDbContext>();

                if (!context.Voertuigen.Any())
                {
                    context.Voertuigen.AddRange(
                        new Voertuig { Merk = "AUDI", MerkType = "A4", Bouwjaar = 2019, Km = 85000, VerkoopPrijs = 24950m, AanwezigInShowroom = true },
                        new Voertuig { Merk = "AUDI", MerkType = "Q5", Bouwjaar = 2021, Km = 42000, VerkoopPrijs = 39900m, AanwezigInShowroom = false },
                        new Voertuig { Merk = "BMW", MerkType = "320d", Bouwjaar = 2018, Km = 120000, VerkoopPrijs = 18500m, AanwezigInShowroom = true },
                        new Voertuig { Merk = "BMW", MerkType = "X3", Bouwjaar = 2022, Km = 30000, VerkoopPrijs = 45750m, AanwezigInShowroom = false },
                        new Voertuig { Merk = "PORSCHE", MerkType = "911", Bouwjaar = 2020, Km = 25000, VerkoopPrijs = 119000m, AanwezigInShowroom = false });

                    context.SaveChanges();
                }
            }
        }
    }
}
