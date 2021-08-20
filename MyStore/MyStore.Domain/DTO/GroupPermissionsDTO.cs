using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    [Table("GroupPermissions")]
    public class GroupPermissionsDTO
    {
        [ForeignKey("Group")]
        public int GroupID { get; set; }
        
        [ForeignKey("Permission")]
        public int PermissionCode { get; set; }
        
        public GroupsDTO Group { get; set; }
        
        public PermissionDTO Permission { get; set; }
    }
}