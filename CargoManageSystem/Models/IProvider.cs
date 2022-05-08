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
        int Insert(T item);
        int Update(T item);
        int Delete(T item);
    }
}
