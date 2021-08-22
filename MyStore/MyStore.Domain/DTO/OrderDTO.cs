using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Domain.DTO
{
    [Table("Orders")]
    public class OrderDTO : BaseDTO
    {
        [ForeignKey("Provider")]
        public int ProviderID { get; set; }
        
        [ForeignKey("User")]
        public int UserID { get; set; }
        
        [Required]
        public DateTime? OrderDate { get; set; }
        
        public DateTime? RequiredDate { get; set; }
        
        [Required]
        public ProviderDTO Provider { get; set; }
        
        [Required]
        public UserDTO User { get; set; }

        public ICollection<OrderDetailsDTO> OrderDetails { get; set; }
    }
}