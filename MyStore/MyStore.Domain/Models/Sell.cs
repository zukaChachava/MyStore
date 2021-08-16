using System;
using System.Collections.Generic;

namespace MyStore.Domain.Models
{
    public class Sell : BaseModel
    {
        public int UserID { get; set; }
        
        public DateTime? SellDate { get; set; }
        
        public User User { get; set; }

        public ICollection<SellDetails> SellDetails { get; set; }

        public override string ToString()
        {
            return $"{ID} {SellDate}";
        }
    }
}