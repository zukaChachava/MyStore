using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Tools;
using MyStore.Repository.Exceptions;
using System.Linq;
using AutoMapper;
using System;

namespace MyStore.Repository
{
    public class UserRepository : BaseRepository<User, UserDTO>
    {
        public UserRepository(AppDbContext context) 
            : base(context, new RepositoryPermission() { Select = 2 })
        {
            
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

        protected override MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
                cfg.CreateMap<User, UserDTO>()
                .ForSourceMember(u => u.Password, ud => ud.DoNotValidate())
                .ReverseMap());
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