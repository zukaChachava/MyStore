using System;

namespace MyStore.Domain.Models
{
    public class ProductDetails : Product
    {
        public DateTime? Valid { get; set; }

        public int Quantity { get; set; } 
    }
}