using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreFilho.Blog.Infra.Data.Context;
using AndreFilho.Blog.Domain.Entities;
using AndreFilho.Blog.Domain.Interfaces.Repository;

namespace AndreFilho.Blog.Infra.Data.Repository
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(BlogContext context) : base(context)
        {
        }
    }
}
