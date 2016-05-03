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
        IEnumerable<Post> PostsByPagination(int pageNo, int pageSize);
        IEnumerable<Post> PostsByTagAndPagination(string tagSlug, int pageNo, int pageSize);
        IEnumerable<Post> PostByCategoryAndPagination(string categorySlug, int pageNo, int pageSize);
        IEnumerable<Post> PostsBySearchAndPagination(string search, int pageNo, int pageSize);
        IEnumerable<Post> PostsByPaginationAndSorting(int pageNo, int pageSize, string sortColumn, bool sortByAscending);
        Post PostByYearMonthAndTitle(int year, int month, string titleSlug);
    }
}
