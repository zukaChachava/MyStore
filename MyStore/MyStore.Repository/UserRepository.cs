using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;
using MyStore.Repository.Exceptions;
using System.Linq;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace MyStore.Repository
{
    public class UserRepository : BaseRepository<User, UserDTO>
    {
        protected Lazy<EmployeeRepository> _employeeRepository;

        public UserRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 2 })
        {
            _employeeRepository = new Lazy<EmployeeRepository>(new EmployeeRepository(_context));
        }

        public User LogIn(string username, string password)
        {
            try
            {
                UserDTO user = _dbSet.Single(x => x.Username == username && x.Password == password);
                return _mapper.Map<User>(user);
            }
            catch(Exception ex)
            {
                throw new UserDoesNotExist("Username or Password is not correct", ex);
            }
        }

        public IEnumerable<Employee> GetEmployees(User user)
        {
            // TODO: Select only not user Employees !
            return _employeeRepository.Value.Select(user);
        }

        public override void Delete(User user, User model)
        {
            if (!HasPermision(user, _repositoryPermission.Delete))
                throw new NotHavePermission("Do not have Delete Permission");

            UserDTO dto = _mapper.Map<UserDTO>(model);
            dto.IsActive = true;
            _dbSet.Update(dto);
        }
    }
}