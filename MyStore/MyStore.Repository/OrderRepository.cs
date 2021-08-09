using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;

namespace MyStore.Repository
{
    public class OrderRepository : BaseRepository<Order, OrderDTO>
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}