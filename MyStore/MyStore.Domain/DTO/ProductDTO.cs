using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    [Table("Products")]
    public class ProductDTO : BaseDTO
    {
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        
        [MaxLength(20)]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required, DefaultValue(false)]
        public bool IsDeleted { get; set; }
        
        [Required]
        public CategoryDTO Category { get; set; }
    }
}