using System;

namespace MyStore.Domain.Models
{
    public class Employee : BaseModel
    {
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string PersonalID { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }
        
        public string HomeAddress { get; set; }
        
        public DateTime? StartJob { get; set; }
        
        public DateTime? EndJob { get; set; }

        public override string ToString()
        {
            return $"{PersonalID} {Lastname}";
        }
    }
}