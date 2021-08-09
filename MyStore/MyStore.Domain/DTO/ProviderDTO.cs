using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    [Table("Providers")]
    public class ProviderDTO : BaseDTO
    {
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Column(TypeName = "varchar(15)"), Required]
        public string Phone { get; set; }
        
        [MaxLength(25)]
        public string Email { get; set; }
        
        [MaxLength(50)]
        public string Location { get; set; }
        
        [Required, DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}