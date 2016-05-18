using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AndreFilho.Blog.Application
{
    public interface IBlogAppService : IDisposable
    {
        IEnumerable<BlogViewModel> GetAllPosts();
        IEnumerable<BlogViewModel> GetPosts(string search, string categoryUrl, string TagUrl);

        SideBarViewModel GetSideBar();
        PostViewModel GetPostByUrlSlug(string slug);

        IEnumerable<BlogViewModel>PostsByCategory(string slug);

        IEnumerable<TagViewModel> GetAllTags();
        IEnumerable<CategoryViewModel> GetAllCategories();

        Tag  AddTag(Tag obj);
        Category AddCategory(Category obj);
        void RemoveTag(Guid id);
        void RemoveCategory(Guid id);

    }
}