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

        public override void Delete(User model)
        {
            UserDTO dto = _mapper.Map<UserDTO>(model);
            dto.IsActive = true;
            _dbSet.Update(dto);
        }
    }
}