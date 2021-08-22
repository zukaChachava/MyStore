using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    [Table("OrderDetails")]
    public class OrderDetailsDTO : BaseDTO
    {
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        
        [Required]
        public decimal UnitPrice { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public DateTime? ProvideDate { get; set; }
        
        [Required]
        public DateTime? Valid { get; set; }

        [Required]
        public OrderDTO Order { get; set; }

        [Required]
        public ProductDTO Product { get; set; }
    }
}