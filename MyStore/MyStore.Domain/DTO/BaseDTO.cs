using System.ComponentModel.DataAnnotations;
using MyStore.Domain.Interfaces;

namespace MyStore.Domain.DTO
{
    public class BaseDTO : IDBO
    {
        [Key]
        public int ID { get; set; }
    }
}