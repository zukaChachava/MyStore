using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    [Table("Employees")]
    public class EmployeeDTO : BaseDTO
    {
        [MaxLength(20), Required]
        public string Firstname { get; set; }
        
        [MaxLength(20), Required]
        public string Lastname { get; set; }
        
        [Column(TypeName = "char(11)"), Required]
        public string PersonalID { get; set; }
        
        [Column(TypeName = "varchar(15)"), Required]
        public string Phone { get; set; }
        
        [MaxLength(30), Required]
        public string Email { get; set; }
        
        [MaxLength(50), Required]
        public string HomeAddress { get; set; }
        
        [Required]
        public DateTime? StartJob { get; set; }
        
        public DateTime? EndJob { get; set; }
        
        [Required, DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}