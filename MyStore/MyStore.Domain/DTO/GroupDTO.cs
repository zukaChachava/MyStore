using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MyStore.Domain.DTO
{
    [Table("Groups")]
    public class GroupDTO : BaseDTO
    {
        [Required, MaxLength(20)]
        public string Name { get; set; }
        
        [Required, MaxLength(20)]
        public string Description { get; set; }
        
        public ICollection<PermissionDTO> Permissions { get; set; }
        
        public ICollection<UserGroupsDTO> UserGroups { get; set; }
        
        public ICollection<GroupPermissionsDTO> GroupPermissions { get; set; }
    }
}