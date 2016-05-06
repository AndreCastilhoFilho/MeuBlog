using AndreFilho.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreFilho.Blog.Domain.Interfaces.Repository
{
   public  interface IPostRepository : IRepository<Post>
    {       
        IEnumerable<Post> PostsByTag(string tagSlug);
        IEnumerable<Post> PostsByCategory(string categorySlug);
        IEnumerable<Post> PostsBySearch(string search);
               
        Post PostByYearMonthAndTitle(int year, int month, string titleSlug);
        Post PostByUrlSlug(string urlSlug);
    }
}
