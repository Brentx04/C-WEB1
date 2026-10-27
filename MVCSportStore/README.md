# MVCSportStore (.NET 10)

ASP.NET Core MVC + Entity Framework Core + SQL Server (LocalDB), volgens "C# Web - 13 Sportstore".

## Starten in Visual Studio
1. Open `MVCSportStore.csproj` (NuGet-pakketten worden automatisch hersteld).
2. Tools > NuGet Package Manager > Package Manager Console:
       Add-Migration initial
       Update-Database
3. Run (F5). Bij de eerste start vult `SeedData.EnsurePopulated` de database met de producten uit `DefaultData`.

## Inhoud
- Data/ – StoreDbContext, DefaultData (productlijst `naam;beschrijving;categorie;prijs`), SeedData
- Models/Product.cs – DataAnnotations + `string[]`-constructor
- ViewModels/ – PagingInfo, ProductModel, PagingSettings (+ PagingSettingsViewModel voor het formulier)
- Controllers/HomeController.cs – DI van StoreDbContext, paging via `?productPage=n`
- Controllers/SettingsController.cs – extra: HttpGet/HttpPost-formulier om ProductPagination te wijzigen (menu "Settings")

De DefaultData-lijst uit Teams mag je gewoon in DefaultData.cs plakken.

## C# Web 16 – TagHelper (toegevoegd aan dit project)
- Models/ – Land, Locatie, Afdeling (reference keys Land 1–n Locatie 1–n Afdeling)
- Data/StoreDbContext.cs – DbSets Landen/Locaties/Afdelingen + startdata via HasData (BE/NL, Brussel/Hasselt/AmsterDam, Aankoop/Verkoop/Onderzoek)
- Controllers + Views – CRUD voor Landen, Locaties, Afdelingen (Include/ThenInclude)
- TagHelpers/ – FirstTagHelper, TitleTagHelper, BoldTagHelper (pagina "TagHelpers" in het menu),
  HyperlinkTagHelper (gekleurde knoppen in _Layout), HeaderFooterTagHelper (Locaties/Index),
  AfdelingCardTagHelper + oefening AfdelingCard2TagHelper met TagBuilder (Afdelingen/Details)
- ViewModels/AfdelingCard.cs

Database bijwerken na deze les (Package Manager Console):
    Add-Migration TagHelper
    Update-Database
(Heb je nog geen migrations? Dan eerst `Add-Migration initial`.)
