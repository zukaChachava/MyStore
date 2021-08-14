using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.Exceptions;
using MyStore.Repository.Interfaces;
using MyStore.Repository.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Repository
{
    public abstract class BaseRepository<TModel, TDTO> : IRepository<TModel> where TModel : BaseModel where TDTO : BaseDTO
    {
        protected readonly AppDbContext _context;
        protected readonly MapperConfiguration _mapperConfiguration;
        protected readonly Mapper _mapper;
        protected readonly Mapper _userMapper;
        protected readonly DbSet<TDTO> _dbSet;
        protected readonly RepositoryPermission _repositoryPermission;

        protected BaseRepository(AppDbContext context, RepositoryPermission permission)
        {
            _context = context;
            _mapperConfiguration = MapperConfiguration();
            _mapper = new Mapper(_mapperConfiguration);
            _userMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>().ReverseMap()));
            _dbSet = _context.Set<TDTO>();
        }

        public virtual TModel Get(int Id)
        {
            return GetModel(_dbSet.Single(x => x.ID == Id));
        }

        public virtual TDTO Get(TModel model)
        {
            return _dbSet.Single(m => m.ID == model.ID);
        }

        public virtual IEnumerable<TModel> Select(User user)
        {
            if (!HasPermision(user, _repositoryPermission.Select))
                throw new NotHavePermission("Do not have Select Permission");

            return _dbSet.Select(x => GetModel(x));
        }

        public virtual IEnumerable<TModel> Select(User user, Predicate<TModel> predicate) => Select(user).Where(x => predicate(x));

        public virtual TModel Add(User user, TModel model)
        {
            if (!HasPermision(user, _repositoryPermission.Add))
                throw new NotHavePermission("Do not have Add Permission");

            TDTO dto = GetDTO(model);
            _dbSet.Add(dto);
            model.ID = dto.ID;
            return model;
        }

        public virtual void Update(User user, TModel model)
        {
            if (!HasPermision(user, _repositoryPermission.Update))
                throw new NotHavePermission("Do not have Update Permission");

            _dbSet.Update(GetDTO(model));
        }

        public virtual void Delete(User user, TModel model)
        {
            if (!HasPermision(user, _repositoryPermission.Delete))
                throw new NotHavePermission("Do not have Delete Permission");

            _dbSet.Remove(GetDTO(model));
        }

        public IEnumerable<int> GetPermissions(User user)
        {
            var dto = _context.Users.Single(ud => ud.ID == user.ID);
            IEnumerable<int> permissions = _context.UserGroups
                .Where(ug => ug.User == dto)
                .Select(ug => ug.Group)
                .SelectMany(g => g.GroupPermissions)
                .Select(gp => gp.PermissionCode);

            string x = permissions.ToString();
            return permissions;
        }

        protected TDTO GetDTO(TModel model) => _mapper.Map<TDTO>(model);

        protected TModel GetModel(TDTO dto) => _mapper.Map<TModel>(dto);

        protected virtual MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
                cfg.CreateMap<TModel, TDTO>()
                .ReverseMap());
        }

        protected bool HasPermision(User user, int permissionCode) => GetPermissions(user).Contains(permissionCode);
    }
}