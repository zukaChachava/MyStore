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
using MyStore.Repository.DomainMapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace MyStore.Repository
{
    public abstract class BaseRepository<TModel, TDTO> : IRepository<TModel> where TModel : BaseModel, new() where TDTO : BaseDTO, new()
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly IMapper _userMapper;
        protected readonly DbSet<TDTO> _dbSet;
        protected readonly RepositoryPermission _repositoryPermission;

        protected BaseRepository(AppDbContext context, RepositoryPermission permission)
        {
            _context = context;
            _repositoryPermission = permission;
            _mapper = ModelMapper.GetMapper<TModel, TDTO>();
            _userMapper = ModelMapper.GetMapper<User, UserDTO>();
            _dbSet = _context.Set<TDTO>();
        }

        public bool TransactionOpended { get; protected set; }

        public virtual TModel Get(int Id)
        {
            return _mapper.Map<TModel>(_dbSet.Single(x => x.ID == Id));
        }

        internal virtual TDTO Get(TModel model)
        {
            return _dbSet.Single(m => m.ID == model.ID);
        }

        public virtual IEnumerable<TModel> Select(User user)
        {
            if (!HasPermision(user, _repositoryPermission.Select))
                throw new NotHavePermission("Do not have Select Permission");

            return _dbSet.Select(x => _mapper.Map<TModel>(x));
        }

        public virtual IEnumerable<TModel> Select(User user, Predicate<TModel> predicate) => Select(user).Where(x => predicate(x));

        internal virtual IEnumerable<TModel> Select(Predicate<TDTO> predicate)
        {
            return _dbSet
                .Where(dto => predicate(dto))
                .Select(dto => _mapper.Map<TModel>(dto));
        }

        public virtual TModel Add(User user, TModel model)
        {
            if (!HasPermision(user, _repositoryPermission.Add))
                throw new NotHavePermission("Do not have Add Permission");

            TDTO dto = _mapper.Map<TDTO>(model);
            _dbSet.Add(dto);
            _context.SaveChanges();
            model.ID = dto.ID;
            return model;
        }

        public virtual void AddMany(User user, IEnumerable<TModel> models)
        {
            if (!HasPermision(user, _repositoryPermission.Add))
                throw new NotHavePermission("Do not have Add Permission");

            foreach (TModel model in models)
                _dbSet.Add(_mapper.Map<TDTO>(model));

            _context.SaveChanges();
        }

        public virtual void Update(User user, TModel model)
        {
            if (!HasPermision(user, _repositoryPermission.Update))
                throw new NotHavePermission("Do not have Update Permission");

            _mapper.Map(model, Get(model));
            _context.SaveChanges();
        }

        public virtual void Delete(User user, TModel model)
        {
            if (!HasPermision(user, _repositoryPermission.Delete))
                throw new NotHavePermission("Do not have Delete Permission");

            _dbSet.Remove(Get(model));
            _context.SaveChanges();
        }

        public virtual void BeginTransaction()
        {
            _context.Database.BeginTransaction();
            TransactionOpended = true;
        }

        public virtual void CommitTransaction()
        {
            _context.Database.CommitTransaction();
            TransactionOpended = false;
        }

        public virtual void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
            TransactionOpended = false;
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

        protected bool HasPermision(User user, int permissionCode) => GetPermissions(user).Contains(permissionCode);
    }
}