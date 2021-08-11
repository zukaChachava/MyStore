using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;

namespace MyStore.Repository
{
    public class ProviderRepository : BaseRepository<Provider, ProviderDTO>
    {
        public ProviderRepository(AppDbContext context) : base(context)
        {
            
        }

        public override void Delete(Provider model)
        {
            ProviderDTO dto = _mapper.Map<ProviderDTO>(model);
            dto.IsDeleted = true;
            _dbSet.Update(dto);
        }
    }
}