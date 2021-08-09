using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    [Table("Users")]
    public class UserDTO : EmployeeDTO
    {
        [MaxLength(20)]
        public string Username { get; set; }
        
        [MaxLength(20)]
        public string Password { get; set; }
    }
}