using System;
using MyStore.Domain.Interfaces;

namespace MyStore.Domain.Models
{
    public class BaseModel : IDBO, IEquatable<BaseModel>
    {
        public int ID { get; set; }

        public bool Equals(BaseModel other) => ID == other.ID;
    }
}