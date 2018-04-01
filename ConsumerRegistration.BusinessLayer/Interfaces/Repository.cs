using System;
using System.Collections.Generic;
using System.Linq;
using ConsumerRegistrationPortal.EntityFramework;
using System.Data;
using ConsumerRegistrationPortal.BusinessLayer.Interfaces;

namespace ConsumerRegistrationPortal.BusinessLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ConsumerRegistrationEntities _dbcontext;

        public Repository(ConsumerRegistrationEntities context)
        {
            _dbcontext = context;
        }

        protected void save() => _dbcontext.SaveChanges();

        public int count(Func<T, bool> predicate)
        {
            return _dbcontext.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _dbcontext.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbcontext.Set<T>();
        }

        public T GetByID(long Id)
        {
            return _dbcontext.Set<T>().Find(Id);
        }

        public void Update(T entity)
        {
            _dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            save();
        }
    }
}
