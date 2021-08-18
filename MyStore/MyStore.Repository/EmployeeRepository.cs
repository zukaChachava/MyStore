using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Exceptions;
using MyStore.Repository.Tools;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Repository
{
    public class EmployeeRepository : BaseRepository<Employee, EmployeeDTO>
    {
        public EmployeeRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 1 } )
        {
            
        }

        public override IEnumerable<Employee> Select(User user)
        {
            if (!HasPermision(user, _repositoryPermission.Select))
                throw new NotHavePermission("Do not have Select Permission");

            return _dbSet
                .Where(ed => ed.IsDeleted == false)
                .Select(ed => _mapper.Map<Employee>(ed));
        }

        public override void Delete(User user, Employee model)
        {
            if (!HasPermision(user, _repositoryPermission.Delete))
                throw new NotHavePermission("Do not have Delete Permission");

            EmployeeDTO dto = _mapper.Map(model, Get(model));
            dto.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}