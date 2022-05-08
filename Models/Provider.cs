using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Models
{
    public abstract class Provider<T> : IProvider<T> where T : class
    {
        public CargoDBEntities dbContext = new Lazy<CargoDBEntities>(() => new CargoDBEntities()).Value;

        public List<T> GetList()
        {
            return dbContext.Set<T>().ToList();
        }

        public T Select(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression).SingleOrDefault();
        }

        public int Delete(T item)
        {
            throw new NotImplementedException();
        }

        public int Insert(T item)
        {
            throw new NotImplementedException();
        }

        public int Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
