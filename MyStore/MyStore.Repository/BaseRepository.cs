﻿using AutoMapper;
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

namespace MyStore.Repository
{
    public abstract class BaseRepository<TModel, TDTO> : IRepository<TModel> where TModel : BaseModel where TDTO : BaseDTO
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

        public virtual TModel Get(int Id)
        {
            return _mapper.Map<TModel>(_dbSet.Single(x => x.ID == Id));
        }

        protected virtual TDTO Get(TModel model)
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

            _dbSet.Remove(_mapper.Map<TDTO>(model));
            _context.SaveChanges();
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