using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;

namespace MyStore.Repository
{
    public class OrderRepository : BaseRepository<Order, OrderDTO>
    {
        public OrderRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 5 })
        {
            
        }
    }
}