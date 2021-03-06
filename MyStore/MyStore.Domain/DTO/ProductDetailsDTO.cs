using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    [Table("ProductDetails")]
    public class ProductDetailsDTO : BaseDTO
    {
        [Required]
        public DateTime? Valid { get; set; }
        
        [Required]
        public int Quantity { get; set; } 

        [Required]
        public ProductDTO Product { get; set; }
    }
}