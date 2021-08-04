using System;
using MyStore.Domain.Interfaces;

namespace MyStore.Domain.Models
{
    public class BaseModel : IDBO
    {
        public int ID { get; set; }
    }
}