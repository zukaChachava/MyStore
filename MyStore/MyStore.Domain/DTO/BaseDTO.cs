using MyStore.Domain.Interfaces;

namespace MyStore.Domain.DTO
{
    public class BaseDTO : IDBO
    {
        public int ID { get; set; }
    }
}