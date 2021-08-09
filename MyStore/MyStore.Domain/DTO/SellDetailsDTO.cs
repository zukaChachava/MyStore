using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    [Table("SellDetails")]
    public class SellDetailsDTO : SellDTO
    {
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public decimal UnitPrice { get; set; }
        
        [Required, DefaultValue(0)]
        public decimal Discount { get; set; }
        
        [Required]
        public ProductDTO Product { get; set; }
    }
}