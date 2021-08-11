using System.Collections.Generic;
using System.ComponentModel;
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
        
        [Required, DefaultValue(true)]
        public bool IsActive { get; set; }
        
        public ICollection<UserGroupsDTO> UserGroups { get; set; }
    }
}