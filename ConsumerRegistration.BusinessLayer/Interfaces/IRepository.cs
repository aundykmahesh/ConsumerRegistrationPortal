using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerRegistrationPortal.BusinessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Func<T, bool> predicate);
        T GetByID(long Id);


        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        int count(Func<T, bool> predicate);
    }
}
