using System;
using System.Linq;
using System.Linq.Expressions;

namespace asWorks.Blog_Tutorial.Data
{
    public interface IRepository:IDisposable
    {
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] include) where T : class;
    }
}