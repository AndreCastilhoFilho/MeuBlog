using AndreFilho.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreFilho.Blog.Infra.Data.Context;
using Dapper;
using AndreFilho.Blog.Domain.Interfaces.Repository;

namespace AndreFilho.Blog.Infra.Data.Repository
{
  public  class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogContext context)
            : base(context)
        {
        }

        public override IEnumerable<Category> GetAll()
        {

            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Categories order by Name";

            return cn.Query<Category>(sql);

        }


    }
}
