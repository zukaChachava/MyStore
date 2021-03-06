namespace MyStore.Domain.Models
{
    public class SellDetails : BaseModel
    {
        public int ProductID { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public decimal Discount { get; set; }

        public override string ToString()
        {
            return $"{ID} {ProductID}";
        }
    }
}