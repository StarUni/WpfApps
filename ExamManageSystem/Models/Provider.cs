using ExamManageSystem.Models;
using Models.BussinessProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Models
{
    public abstract class Provider<T> : IProvider<T> where T : class
    {
        public EMSDBContext _dbContext;

        public Provider(EMSDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<T> GetList()
        {
            return _dbContext.Set<T>().ToList();
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression).ToList();
        }

        public T Select(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression).SingleOrDefault();
        }

        public int Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
            var t = _dbContext.SaveChanges();
            return t;
        }

        public int Insert(T item)
        {
            _dbContext.Set<T>().Add(item);
            var t = _dbContext.SaveChanges();
            return t;
        }

        public int InsertRange(IEnumerable<T> items)
        {
            _dbContext.Set<T>().AddRange(items);
            var t = _dbContext.SaveChanges();
            return t;
        }

        public int Update(T item)
        {
            if (item.Equals(null)) return -1;
            _dbContext.Entry(item).CurrentValues.SetValues(item);
            var t = _dbContext.SaveChanges();
            return t;
        }
    }
}
