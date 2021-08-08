using System;

namespace MyStore.Domain.Models
{
    public class Order : BaseModel
    {
        public int ProviderID { get; set; }
        
        public int UserID { get; set; }
        
        public DateTime? OrderDate { get; set; }
        
        public DateTime? RequiredDate { get; set; }
        
        public Provider Provider { get; set; }
        
        public User User { get; set; }
    }
}