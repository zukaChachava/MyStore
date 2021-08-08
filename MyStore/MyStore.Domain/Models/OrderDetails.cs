using System;

namespace MyStore.Domain.Models
{
    public class OrderDetails : Order
    {
        public int ProductID { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public int Quantity { get; set; }
        
        public DateTime? ProvideDate { get; set; }
        
        public DateTime? Valid { get; set; }
        
        public Product Product { get; set; }
    }
}