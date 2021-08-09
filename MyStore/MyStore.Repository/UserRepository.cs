using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;

namespace MyStore.Repository
{
    public class UserRepository : BaseRepository<User, UserDTO>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}