using AndreFilho.Blog.Domain.Interfaces.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Entities;
using AndreFilho.Blog.Infra.Data.Interfaces;
using AutoMapper;

namespace AndreFilho.Blog.Application.Services
{
    public class BlogAppService : ApplicationService, IBlogAppService
    {

        private readonly IBlogService _blogService;

        public BlogAppService(IBlogService blogService, IUnitOfWork wow)
            : base(wow)
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

        public IEnumerable<BlogViewModel> GetPostsBySearchCategoryAndTag(string search, string categoryUrl, string TagUrl)
        {
            return Mapper.Map<IEnumerable<Post>, IEnumerable<BlogViewModel>>(_blogService.GetPostsBySearchCategoryAndTag(search, categoryUrl, TagUrl));

        }

        public IEnumerable<TagViewModel> GetAllTags()
        {
            return Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(_blogService.GetAllTags());
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(_blogService.GetAllCategories());
        }

        public TagViewModel AddTag(TagViewModel obj)
        {
            BeginTransaction();
            var tag = Mapper.Map<TagViewModel, Tag>(obj);
            _blogService.AddTag(tag);
            Commit();

            return obj;
        }

        public CategoryViewModel AddCategory(CategoryViewModel obj)
        {
            BeginTransaction();
            var category = Mapper.Map<CategoryViewModel, Category>(obj);
            _blogService.AddCategory(category);
            Commit();

            return obj;
        }

        public void RemoveTag(Guid id)
        {
            BeginTransaction();
            _blogService.RemoveTag(id);
            Commit();
        }

        public void RemoveCategory(Guid id)
        {

            _blogService.RemoveCategory(id);

        }

        public TagViewModel GetTagById(Guid id)
        {
            return    Mapper.Map<Tag, TagViewModel>( _blogService.GetTagById(id));
        }

        public CategoryViewModel GetCategoryById(Guid id)
        {
            return Mapper.Map<Category, CategoryViewModel>(_blogService.GetCategoryById(id));
        }

        public IEnumerable<BlogViewModel> GetPostsBySearch(string search)
        {
            return Mapper.Map<IEnumerable<Post>, IEnumerable<BlogViewModel>>(_blogService.PostsBySearch(search));
        }
    }
}
