using AndreFilho.Blog.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            

            return _postRepository.Add(obj);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Post GetById(Guid id)
        {
            return _postRepository.GetById(id);
        }


        public Post PostByYearMonthAndTitle(int year, int month, string titleSlug)
        {
            return _postRepository.PostByYearMonthAndTitle(year, month, titleSlug);
        }
                
        public IEnumerable<Post> PostsBySearch(string search)
        {
            return _postRepository.PostsBySearch(search);
        }

        public IEnumerable<Post> PostsByTag(string tagSlug)
        {
            return _postRepository.PostsByTag(tagSlug);
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

        public Post PostByUrlSlug(string urlSlug)
        {
            return _postRepository.PostByUrlSlug(urlSlug);
        }

        public IEnumerable<Post> PostsByCategory(string slug)
        {
            return _postRepository.PostsByCategory(slug);
        }

        public IEnumerable<Post> GetPostsBySearchCategoryAndTag(string search, string categoryUrl, string tagUrl)
        {
            var posts = _postRepository.PostsByCategory(categoryUrl);

            if (search != null && !String.IsNullOrEmpty(search))
                posts = posts.Where(p => 
                (p.Title.Contains(search)
                || p.Category.Name.Equals(search)
                || p.Tags.Any(t => t.Name.Equals(search))));

            if (tagUrl != null && !String.IsNullOrEmpty(tagUrl))
                posts = posts.Where(p => p.Tags.Any(t => t.UrlSlug.Equals(tagUrl)));


            return posts;




        }
    }
}
