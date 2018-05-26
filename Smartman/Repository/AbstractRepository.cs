using Interface;
using Microsoft.EntityFrameworkCore;
using Smartman.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smartman.Repository
{
    public abstract class AbstractRepository<T, IdType> : IRepository<T, IdType> where T : class
    {
        protected readonly SmartmanDbContext _dbContext;

        protected Action<T> RunAction { get; set; }

        protected AbstractRepository(SmartmanDbContext context)
        {
            _dbContext = context;
        }

        public virtual T Add(T obj)
        {
            RunAction?.Invoke(obj);
            var entity = _dbContext.Add<T>(obj).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual T Delete(T obj)
        {
            RunAction?.Invoke(obj);
            var entity = _dbContext.Remove(obj).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual T Edit(T obj)
        {
            RunAction?.Invoke(obj);
            try
            {
                var entity = _dbContext.Update(obj).Entity;
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

         protected bool IsEntityTracking<U>(U entity) where U : class
        {
            var state = _dbContext.Entry(entity).State;
            if (state != EntityState.Detached)
            {
                return true;
            }
            return false;
        }
        public void DetachAll()
        {
            var trackedEntities = _dbContext.ChangeTracker.Entries().ToArray();
            for (int i = 0; i < trackedEntities.Length; i++)
            {
                trackedEntities[i].State = EntityState.Detached;
            }
        }

        public abstract IEnumerable<T> Get();

        public abstract T GetById(IdType id);
    }
}