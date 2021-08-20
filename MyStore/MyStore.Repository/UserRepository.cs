using AutoMapper;
using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.DomainMapper;
using MyStore.Repository.Exceptions;
using MyStore.Repository.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyStore.Repository
{
    public class UserRepository : BaseRepository<User, UserDTO>
    {
        internal Lazy<GroupRepository> _groupRepository;

        public UserRepository(AppDbContext context)
            : base(context, new RepositoryPermission() { Select = 2 })
        {
            _groupRepository = new Lazy<GroupRepository>(new GroupRepository(_context));
        }

        public User LogIn(string username, string password)
        {
            try
            {
                UserDTO user = _dbSet.Single(x => x.Username == username && x.Password == password);
                return _mapper.Map<User>(user);
            }
            catch (Exception ex)
            {
                throw new UserDoesNotExist("Username or Password is not correct", ex);
            }
        }

        public IEnumerable<Employee> GetEmployees(User user)
        {
            IMapper mapper = ModelMapper.GetMapper<Employee, EmployeeDTO>();
            return _context.Employees
                .Where(e => !_dbSet.Any(u => u.ID == e.ID))
                .Where(e => e.IsDeleted == false)
                .Select(e => mapper.Map<Employee>(e));
        }

        //public override User Add(User adminUser, User model)
        //{
        //    EmployeeDTO employee = _context.Employees.Single(e => e.ID == model.ID);
            

        //    _context.SaveChanges();
        //    return _mapper.Map<User>();
        //}

        public override void Delete(User adminUser, User model)
        {
            if (!HasPermision(adminUser, _repositoryPermission.Delete))
                throw new NotHavePermission("Do not have Delete Permission");

            UserDTO dto = _mapper.Map(model, Get(model));
            dto.IsActive = false;
            _context.SaveChanges();
        }

        public void ChangeUserGroups(User adminUser, User model, params Groups[] groups)
        {
            UserDTO dto = Get(model);
            Stack<GroupsDTO> groupDTOs = new();

            foreach (Groups group in groups)
                if (group != null)
                    groupDTOs.Push(_groupRepository.Value.Get(group));

            try
            {
                _context.Database.BeginTransaction();
                _context.UserGroups
                    .RemoveRange(_context.UserGroups.Where(ug => ug.User == dto));

                foreach (GroupsDTO groupDto in groupDTOs)
                    _context.UserGroups.Add(new UserGroupsDTO() { User = dto, Group = groupDto });
            }
            catch
            {
                _context.Database.RollbackTransaction();
                throw;
            }
            _context.Database.CommitTransaction();
            _context.SaveChanges();
        }

        public IEnumerable<Groups> GetUserGroups(User adminUser, User user)
        {
            IMapper mapper = ModelMapper.GetMapper<Groups, GroupsDTO>();
            return _context.UserGroups
                .Where(ug => ug.User == Get(user))
                .Select(ug => mapper.Map<Groups>(ug.Group));
        }

        public Groups GetAdminGroup()
        {
            return _groupRepository.Value.Get(1);
        }

        public Groups GetManagerGroup()
        {
            return _groupRepository.Value.Get(2);
        }

        public Groups GetCashierGroup()
        {
            return _groupRepository.Value.Get(3);
        }

        public Groups GetSupplyManager()
        {
            return _groupRepository.Value.Get(4);
        }
    }
}