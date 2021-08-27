using System;

namespace MyStore.Domain.Models
{
    public class ProductDetails : BaseModel
    {
        public DateTime? Valid { get; set; }

        public int? Quantity { get; set; }

        public override string ToString()
        {
            return $"{ID} {Quantity}";
        }
    }
}