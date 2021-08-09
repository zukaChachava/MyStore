using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;

namespace MyStore.Repository
{
    public class SellRepository : BaseRepository<Sell, SellDTO>
    {
        public SellRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}