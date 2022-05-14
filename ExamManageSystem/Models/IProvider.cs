using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IProvider<T>where T : class
    {
        T Select(Expression<Func<T, bool>> expression);
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> expression);
        int Insert(T item);
        int InsertRange(IEnumerable<T> items);
        int Update(T item);
        int Delete(T item);
    }
}
