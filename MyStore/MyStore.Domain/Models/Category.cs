namespace MyStore.Domain.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}