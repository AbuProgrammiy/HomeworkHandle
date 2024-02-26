using System.ComponentModel.DataAnnotations;

namespace Bi1Market.DTOs
{
    public class ProductDTO
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required int Price { get; set; }
    }
}
