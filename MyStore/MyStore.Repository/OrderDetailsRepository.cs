using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;

namespace MyStore.Repository
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails, OrderDetailsDTO>
    {
        public OrderDetailsRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}