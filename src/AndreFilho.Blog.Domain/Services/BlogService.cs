using System;
using System.Collections.Generic;
using System.Linq;
using AndreFilho.Blog.Domain.Entities;
using AndreFilho.Blog.Domain.Interfaces.Repository;
using AndreFilho.Blog.Domain.Interfaces.Services;

namespace AndreFilho.Blog.Domain.Services
{
    public class BlogService : IBlogService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;


        public BlogService(ICategoryRepository categoryRepository, IPostRepository postRepository, ITagRepository tagRepository)
        {
            _categoryRepository = categoryRepository;
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }

        public Category AddCategory(Category obj)
        {
           return _categoryRepository.Add(obj);
        }

        public Tag AddTag(Tag obj)
        {
            return _tagRepository.Add(obj);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _tagRepository.Dispose();
            _categoryRepository.Dispose();
            _postRepository.Dispose();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll().OrderBy(c=>c.Description);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.GetAll();
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _tagRepository.GetAll().OrderBy(t=>t.Description);
        }

        public Post GetPostByUrlSlug(string slug)
        {
            return _postRepository.PostByUrlSlug(slug);
        }

        public IEnumerable<Post> GetPostsBySearchCategoryAndTag(string search, string category, string tag)
        {
            var posts = _postRepository.PostsByCategory(category);

            if (search != null && !String.IsNullOrEmpty(search))
                posts = posts.Where(p =>
                (p.Title.Contains(search)
                || p.Category.Name.Equals(search)
                || p.Tags.Any(t => t.Name.Equals(search))));

            if (tag != null && !String.IsNullOrEmpty(tag))
                posts = posts.Where(p => p.Tags.Any(t => t.UrlSlug.Equals(tag)));
            
            return posts;

        }

        public IEnumerable<Post> PostsByCategory(string urlSlug)
        {
            return _postRepository.PostsByCategory(urlSlug);
        }

        public void RemoveCategory(Guid id)
        {
          _categoryRepository.Remove(id);
        }

        public Tag GetTagById(Guid id)
        {
            return _tagRepository.GetById(id);
        }

        public Category GetCategoryById(Guid id)
        {
            return _categoryRepository.GetById(id);
        }

        public void RemoveTag(Guid id)
        {
           _tagRepository.Remove(id);
        }

        public IEnumerable<Post> PostsBySearch(string search)
        {
            return _postRepository.PostsBySearch(search);
        }
    }
}