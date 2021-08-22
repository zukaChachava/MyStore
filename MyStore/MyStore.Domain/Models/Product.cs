using System.Collections.Generic;

namespace MyStore.Domain.Models
{
    public class Product : BaseModel
    {
        public int CategoryID { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}