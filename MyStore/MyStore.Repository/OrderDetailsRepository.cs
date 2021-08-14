using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;

namespace MyStore.Repository
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails, OrderDetailsDTO>
    {
        public OrderDetailsRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 6 })
        {
            
        }
    }
}