using System;
using System.Collections.Generic;
using AndreFilho.Blog.Domain.Entities;

namespace AndreFilho.Blog.Domain.Interfaces.Services
{
    public interface IBlogService : IDisposable
    {

        IEnumerable<Post> GetAllPosts();
        Post GetPostByUrlSlug(string urlSlug);

        IEnumerable<Post> PostsByCategory(string category);
        IEnumerable<Post> GetPostsBySearchCategoryAndTag(string search, string category, string tag);


        IEnumerable<Tag> GetAllTags();
        IEnumerable<Category> GetAllCategories();

        Tag AddTag(Tag obj);
        Category AddCategory(Category obj);
        void RemoveTag(Guid id);
        void RemoveCategory(Guid id);
        Tag GetTagById(Guid id);
        Category GetCategoryById(Guid id);
    }
}