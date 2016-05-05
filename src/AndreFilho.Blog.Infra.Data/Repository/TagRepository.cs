using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreFilho.Blog.Infra.Data.Context;
using AndreFilho.Blog.Domain.Entities;

namespace AndreFilho.Blog.Infra.Data.Repository
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(BlogContext context) : base(context)
        {
        }
    }
}
