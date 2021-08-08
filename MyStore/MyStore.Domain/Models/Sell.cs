using System;

namespace MyStore.Domain.Models
{
    public class Sell : BaseModel
    {
        public int UserID { get; set; }
        
        public DateTime? SellDate { get; set; }
        
        public User User { get; set; }
    }
}