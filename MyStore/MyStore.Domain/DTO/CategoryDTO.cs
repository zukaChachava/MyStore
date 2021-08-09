using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    [Table("Categories")]
    public class CategoryDTO : BaseDTO
    {
        [MaxLength(20), Required]
        public string Name { get; set; }
        
        [Required, DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}