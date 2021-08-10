using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    public class UserGroupsDTO
    {
        [ForeignKey("User")]
        public int UserID { get; set; }
        
        [ForeignKey("Group")]
        public int GroupID { get; set; }
        
        public UserDTO User{ get; set; }
        
        public GroupDTO Group { get; set; }
    }
}