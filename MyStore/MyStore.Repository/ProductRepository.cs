using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;
using MyStore.Repository.Exceptions;

namespace MyStore.Repository
{
    public class ProductRepository : BaseRepository<Product, ProductDTO>
    {
        public ProductRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 7 })
        {
            
        }

        public override void Delete(User user, Product model)
        {
            if (!HasPermision(user, _repositoryPermission.Delete))
                throw new NotHavePermission("Do not have Delete Permission");

            ProductDTO dto = _mapper.Map<ProductDTO>(model);
            dto.IsDeleted = true;
            _dbSet.Update(dto);
        }
    }
}