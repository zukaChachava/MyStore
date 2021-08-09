using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;

namespace MyStore.Repository
{
    public class SellDetailsRepository : BaseRepository<SellDetails, SellDetailsDTO>
    {
        public SellDetailsRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}