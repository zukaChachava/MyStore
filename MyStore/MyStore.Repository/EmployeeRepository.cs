using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Exceptions;
using MyStore.Repository.Tools;

namespace MyStore.Repository
{
    public class EmployeeRepository : BaseRepository<Employee, EmployeeDTO>
    {
        public EmployeeRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 1 } )
        {
            
        }

        public override void Delete(User user, Employee model)
        {
            if (!HasPermision(user, _repositoryPermission.Delete))
                throw new NotHavePermission("Do not have Delete Permission");

            EmployeeDTO dto = _mapper.Map<EmployeeDTO>(model);
            dto.IsDeleted = true;
            _dbSet.Update(dto);
        }
    }
}