using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AndreFilho.Blog.Application
{
    public interface IBlogAppService : IDisposable
    {
        IEnumerable<BlogViewModel> GetAll();

        SideBarViewModel GetSideBar();
   
        PostViewModel getPostByUrlSlugslug(string slug);
    }
}