using System.ComponentModel.DataAnnotations;

namespace MVCVoertuig.Validation
{
    // Stap 6 - Custom model validatie
    // 1. Erf over van ValidationAttribute
    // 2. Naam eindigt op "Attribute" -> in het model gebruik je [Bouwjaar]
    // 3. Override IsValid en geef ValidationResult.Success of een foutmelding terug
    public class BouwjaarAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int bouwjaar = Convert.ToInt32(value);
            int huidigJaar = DateTime.Now.Year;

            if (bouwjaar < 1900 || bouwjaar > huidigJaar)
            {
                return new ValidationResult($"Bouwjaar moet tussen 1900 en {huidigJaar} liggen");
            }

            return ValidationResult.Success;
        }
    }
}
