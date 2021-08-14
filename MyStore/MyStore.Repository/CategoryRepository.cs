using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Exceptions;
using MyStore.Repository.Tools;

namespace MyStore.Repository
{
    public class CategoryRepository : BaseRepository<Category, CategoryDTO>
    {
        public CategoryRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 4})
        {
        }

        public override void Delete(User user, Category model)
        {
            if (!HasPermision(user, _repositoryPermission.Delete))
                throw new NotHavePermission("Do not have Delete Permission");

            CategoryDTO dto = _mapper.Map<CategoryDTO>(model);
            dto.IsDeleted = true;
            _dbSet.Update(dto);
        }
    }
}