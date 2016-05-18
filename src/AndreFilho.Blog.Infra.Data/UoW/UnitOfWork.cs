using AndreFilho.Blog.Infra.Data.Context;
using AndreFilho.Blog.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreFilho.Blog.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly BlogContext _context;
        private bool _disposed;

        public UnitOfWork(BlogContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
