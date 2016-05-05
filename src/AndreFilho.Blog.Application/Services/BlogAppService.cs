using AndreFilho.Blog.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Entities;
using AutoMapper;

namespace AndreFilho.Blog.Application.Services
{
    public class BlogAppService : IBlogAppService
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public BlogAppService(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public void Dispose()
        {
            _postService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<BlogViewModel> GetAll()
        {
            var posts = Mapper.Map<IEnumerable<Post>, IEnumerable<BlogViewModel>>(_postService.GetAll());
            return posts;
        }

        public SideBarViewModel GetSideBar()
        {
            SideBarViewModel sideBar = new SideBarViewModel();

            var categories = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(_categoryService.GetAll());

            sideBar.Categories = categories;

            return sideBar;
            
        }

        public PostViewModel getPostByUrlSlugslug(string slug)
        {
            
            return Mapper.Map<Post, PostViewModel>(_postService.BostByUrlSlug(slug));
        }
    }
}
