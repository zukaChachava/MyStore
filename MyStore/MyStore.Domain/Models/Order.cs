using System;
using System.Collections.Generic;

namespace MyStore.Domain.Models
{
    public class Order : BaseModel
    {
        public int ProviderID { get; set; }
        
        public int UserID { get; set; }
        
        public DateTime? OrderDate { get; set; }
        
        public DateTime? RequiredDate { get; set; }

        public override string ToString()
        {
            return $"{ID} {OrderDate}";
        }
    }
}