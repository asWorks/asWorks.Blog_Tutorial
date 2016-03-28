using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using asWorks.Blog_Tutorial.Data;
using asWorks.Blog_Tutorial.Entity;
using System.Linq.Expressions;
using System.Data.Entity;


namespace asWorks.Blog_Tutorial.Data.Repository
{
    public class BlogRepository : IRepository
    {
        private readonly Blog_TutorialEntityContext _context;

        public BlogRepository()
        {
            _context = new Blog_TutorialEntityContext();
        }
     
        public IQueryable<T> All<T>() where T :class
        {
            return _context.Set<T>();
        }

        public IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] include) where T : class
        {


          IQueryable<T> retfile = _context.Set<T>();

            foreach (var  item in include)
            {
                retfile = retfile.Include(item);
            }

            return retfile;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
