using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    [Table("Permissions")]
    public class PermissionDTO : BaseDTO
    {
        [Required]
        public int? PermissionCode { get; set; }
        
        [MaxLength(100)]
        public string Description { get; set; }
        
        public ICollection<GroupPermissionsDTO> GroupPermissions { get; set; }
    }
}