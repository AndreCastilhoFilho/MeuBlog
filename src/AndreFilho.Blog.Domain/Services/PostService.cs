using AndreFilho.Blog.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreFilho.Blog.Domain.Entities;
using AndreFilho.Blog.Domain.Interfaces.Repository;

namespace AndreFilho.Blog.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public Post Add(Post obj)
        {
           return  _postRepository.Add(obj);
        }
         
        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Post GetById(Guid id)
        {
            return _postRepository.GetById(id);
        }

        public IEnumerable<Post> PostByCategoryAndPagination(string categorySlug, int pageNo, int pageSize)
        {
           return  _postRepository.PostByCategoryAndPagination(categorySlug, pageNo, pageSize);
        }

        public Post PostByYearMonthAndTitle(int year, int month, string titleSlug)
        {
            return _postRepository.PostByYearMonthAndTitle(year, month, titleSlug);
        }

        public IEnumerable<Post> PostsByPagination(int pageNo, int pageSize)
        {
            return _postRepository.PostsByPagination(pageSize, pageSize);
        }

        public IEnumerable<Post> PostsByPaginationAndSorting(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            return _postRepository.PostsByPaginationAndSorting(pageNo, pageSize, sortColumn, sortByAscending);
        }

        public IEnumerable<Post> PostsBySearchAndPagination(string search, int pageNo, int pageSize)
        {
            return _postRepository.PostsBySearchAndPagination(search, pageNo, pageSize);
        }

        public IEnumerable<Post> PostsByTagAndPagination(string tagSlug, int pageNo, int pageSize)
        {
            return _postRepository.PostsByTagAndPagination(tagSlug, pageNo, pageSize);
        }

        public void Remove(Guid id)
        {
             _postRepository.Remove(id);
        }

        public int TotalPosts(bool checkIsPublished = true)
        {
            return GetAll().Where(p => p.Published == checkIsPublished).Count();
        }

        public int TotalPostsForSearch(string search)
        {
          return GetAll().Where(p => p.Published && (p.Title.Contains(search) 
          || p.Category.Name.Equals(search) 
          || p.Tags.Any(t => t.Name.Equals(search))))             
          .Count();
        }

        public int TotalPostsForTag(string tagSlug)
        {
           return GetAll().Where(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(tagSlug)))
                     .Count();
        }

        public Post Update(Post obj)
        {
            return _postRepository.Update(obj);
        }

        public void Dispose()
        {
            _postRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Post BostByUrlSlug(string urlSlug)
        {
            return _postRepository.PostByUrlSlug(urlSlug);
        }
    }
}
