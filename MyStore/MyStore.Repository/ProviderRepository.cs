using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;
using MyStore.Repository.Exceptions;

namespace MyStore.Repository
{
    public class ProviderRepository : BaseRepository<Provider, ProviderDTO>
    {
        public ProviderRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 3 })
        {
            
        }

        public override void Delete(User user, Provider model)
        {
            if (!HasPermision(user, _repositoryPermission.Delete))
                throw new NotHavePermission("Do not have Delete Permission");

            ProviderDTO dto = _mapper.Map<ProviderDTO>(model);
            dto.IsDeleted = true;
            _dbSet.Update(dto);
        }
    }
}