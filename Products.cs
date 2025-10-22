using System.ComponentModel.DataAnnotations;

namespace Assignment4.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, 9999)]
        public decimal Price { get; set; }

        [Range(0, 9999)]
        public int Quantity { get; set; }

        [Range(0.01, 9999)]
        public decimal Weight { get; set; }
    }
}
