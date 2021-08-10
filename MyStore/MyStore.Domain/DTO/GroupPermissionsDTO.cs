using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    [Table("GroupPermissions")]
    public class GroupPermissionsDTO
    {
        [ForeignKey("Group")]
        public int GroupID { get; set; }
        
        [ForeignKey("Permission")]
        public int PermissionID { get; set; }
        
        public GroupDTO Group { get; set; }
        
        public PermissionDTO Permission { get; set; }
    }
}