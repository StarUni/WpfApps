﻿using ExamManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Models
{
    public abstract class Provider<T> : IProvider<T> where T : class
    {
        public EMDBEntities dbContext = new Lazy<EMDBEntities>(() => new EMDBEntities()).Value;

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
            dbContext.Set<T>().Remove(item);
            var t = dbContext.SaveChanges();
            return t;
        }

        public int Insert(T item)
        {
            dbContext.Set<T>().Add(item);
            var t = dbContext.SaveChanges();
            return t;
        }

        public int Update(T item)
        {
            if(item.Equals(null)) return -1;
            try
            {
                dbContext.Entry(item).CurrentValues.SetValues(item);
                var t = dbContext.SaveChanges();
                return t;
            }
            catch (DbEntityValidationException dbException)
            {
                throw;
            }
            
        }
    }
}