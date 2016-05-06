using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AndreFilho.Blog.Application
{
    public interface IBlogAppService : IDisposable
    {
        IEnumerable<BlogViewModel> GetAll();
        IEnumerable<BlogViewModel> GetPosts(string search, string categoryUrl, string TagUrl);

        SideBarViewModel GetSideBar();
        PostViewModel getPostByUrlSlug(string slug);

        IEnumerable<BlogViewModel>PostsByCategory(string slug);

    }
}