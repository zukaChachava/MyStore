using System;
using System.Collections.Generic;

namespace MyStore.Domain.Models
{
    public class Sell : BaseModel
    {
        public int UserID { get; set; }
        
        public DateTime? SellDate { get; set; }

        public override string ToString()
        {
            return $"{ID} {SellDate}";
        }
    }
}