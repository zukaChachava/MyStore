namespace MyStore.Domain.Models
{
    public class User : Employee
    {
        public string Username { get; set; }
        
        public string Password { get; set; }

        public override string ToString()
        {
            return Username;
        }
    }
}