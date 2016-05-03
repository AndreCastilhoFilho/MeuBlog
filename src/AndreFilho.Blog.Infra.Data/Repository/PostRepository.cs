using AndreFilho.Blog.Domain.Entities;
using AndreFilho.Blog.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreFilho.Blog.Infra.Data.Context;

namespace AndreFilho.Blog.Infra.Data.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(BlogContext context) 
            : base(context)
        {
        }

        public IEnumerable<Post> PostByCategoryAndPagination(string categorySlug, int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Post PostByYearMonthAndTitle(int year, int month, string titleSlug)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> PostsByPagination(int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> PostsByPaginationAndSorting(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> PostsBySearchAndPagination(string search, int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> PostsByTagAndPagination(string tagSlug, int pageNo, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
