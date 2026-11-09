using Microsoft.EntityFrameworkCore;
using MVCVoertuig.Data;

var builder = WebApplication.CreateBuilder(args);

// Stap 3 + 4 - Connection string uit appsettings.json lezen en de DbContext registreren
var connectionString = builder.Configuration.GetConnectionString("VoertuigConnection");

builder.Services.AddDbContext<VoertuigDbContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Stap 10 - Default data oproepen in de startklasse (na Build, voor Run)
SeedData.EnsurePopulated(app);

app.Run();
