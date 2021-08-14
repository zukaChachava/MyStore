using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;

namespace MyStore.Repository
{
    public class SellRepository : BaseRepository<Sell, SellDTO>
    {
        public SellRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 8 })
        {
            
        }
    }
}