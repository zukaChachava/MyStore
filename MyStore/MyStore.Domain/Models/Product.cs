using System.Collections.Generic;

namespace MyStore.Domain.Models
{
    public class Product : BaseModel
    {
        public int CategoryID { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public Category Category { get; set; }

        public ICollection<ProductDetails> ProductDetails { get; set; }

        public ICollection<SellDetails> SellDetails { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}