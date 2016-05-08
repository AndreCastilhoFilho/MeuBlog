using AndreFilho.Blog.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using AndreFilho.Blog.Infra.Data.Context;
using System.Data.Entity;

namespace AndreFilho.Blog.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected BlogContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(BlogContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Add(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);

            SaveChanges();
            return objReturn;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public TEntity Update(TEntity obj)
        {

            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();
            return obj;
        }
    }
}
