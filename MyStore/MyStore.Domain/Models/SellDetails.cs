namespace MyStore.Domain.Models
{
    public class SellDetails : Sell
    {
        public int ProductID { get; set; }
        
        public int Quantity { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public decimal Discount { get; set; }
        
        public Product Product { get; set; }
    }
}