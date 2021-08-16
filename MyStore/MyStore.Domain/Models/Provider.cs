namespace MyStore.Domain.Models
{
    public class Provider : BaseModel
    {
        public string Name { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }
        
        public string Location { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}