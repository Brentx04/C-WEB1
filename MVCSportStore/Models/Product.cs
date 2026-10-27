using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace MVCSportStore.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string[] data)
        {
            //name;description;category;price
            Name = data[0];
            Description = data[1];
            Category = data[2];
            // InvariantCulture: "48.95" wordt anders als 4895 gelezen op een Belgische (nl-BE) pc
            Price = decimal.Parse(data[3], CultureInfo.InvariantCulture);
        }

        public long ProductId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        public string? Category { get; set; }
    }
}
