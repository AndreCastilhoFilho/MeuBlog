using System;
using System.Collections.Generic;
using AndreFilho.Blog.Application.Interfaces;
using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Entities;
using AndreFilho.Blog.Domain.Interfaces.Services;
using AutoMapper;

namespace AndreFilho.Blog.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;

        public CategoryAppService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public CategoryViewModel Add(CategoryViewModel obj)
        {
            var category = Mapper.Map<CategoryViewModel, Category>(obj);
            _categoryService.Add(category);
            return obj;
        }

        public CategoryViewModel GetById(Guid id)
        {
            return Mapper.Map<Category, CategoryViewModel>(_categoryService.GetById(id));
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(_categoryService.GetAll());
        }

        public CategoryViewModel Update(CategoryViewModel obj)
        {
            var post = Mapper.Map<CategoryViewModel, Category>(obj);

            return obj;
        }

        public void Remove(Guid id)
        {
         _categoryService.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _categoryService.Dispose();
        }
    }
}