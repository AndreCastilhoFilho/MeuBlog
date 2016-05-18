using AndreFilho.Blog.Domain.Interfaces.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Entities;
using AutoMapper;

namespace AndreFilho.Blog.Application.Services
{
    public class BlogAppService : IBlogAppService
    {
       
        private readonly IBlogService _blogService;

        public BlogAppService(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public void Dispose()
        {
            _blogService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<BlogViewModel> GetAllPosts()
        {
            var posts = Mapper.Map<IEnumerable<Post>, IEnumerable<BlogViewModel>>(_blogService.GetAllPosts());
            return posts;
        }

        public SideBarViewModel GetSideBar()
        {
            SideBarViewModel sideBar = new SideBarViewModel();

            var categories = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(_blogService.GetAllCategories());

            sideBar.Categories = categories;

            return sideBar;
            
        }

        public PostViewModel GetPostByUrlSlug(string slug)
        {
            
            return Mapper.Map<Post, PostViewModel>(_blogService.GetPostByUrlSlug(slug));
        }

        public IEnumerable<BlogViewModel> PostsByCategory(string slug)
        {

            return Mapper.Map<IEnumerable<Post>, IEnumerable<BlogViewModel>>(_blogService.PostsByCategory(slug));

        }

        public IEnumerable<BlogViewModel> GetPosts(string search, string categoryUrl, string TagUrl)
        {
            return Mapper.Map<IEnumerable<Post>, IEnumerable<BlogViewModel>>(_blogService.GetPostsBySearchCategoryAndTag(search,categoryUrl, TagUrl));

        }

        public IEnumerable<TagViewModel> GetAllTags()
        {
            return Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(_blogService.GetAllTags());
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
           return Mapper.Map< IEnumerable<Category>, IEnumerable < CategoryViewModel >> (_blogService.GetAllCategories());
        }

        public Tag AddTag(Tag obj)
        {
            return _blogService.AddTag(obj);
        }

        public Category AddCategory(Category obj)
        {
            return _blogService.AddCategory(obj);
        }

        public void RemoveTag(Guid id)
        {
            _blogService.RemoveTag(id);
        }

        public void RemoveCategory(Guid id)
        {
            
          _blogService.RemoveCategory(id);
            
        }
    }
}
