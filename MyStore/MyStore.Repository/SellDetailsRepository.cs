using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;

namespace MyStore.Repository
{
    public class SellDetailsRepository : BaseRepository<SellDetails, SellDetailsDTO>
    {
        public SellDetailsRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 9 })
        {
            
        }
    }
}