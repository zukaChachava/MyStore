using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    public class SellDTO : BaseDTO
    {
        [ForeignKey("User")]
        public int UserID { get; set; }
        
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? SellDate { get; set; }
        
        [Required]
        public UserDTO User { get; set; }
    }
}