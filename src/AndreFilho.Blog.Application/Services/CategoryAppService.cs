using System;
using System.Collections.Generic;
using AndreFilho.Blog.Application.Interfaces;
using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Entities;
using AndreFilho.Blog.Domain.Interfaces.Services;
using AutoMapper;
using AndreFilho.Blog.Infra.Data.Interfaces;

namespace AndreFilho.Blog.Application.Services
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly ICategoryService _categoryService;

        public CategoryAppService(ICategoryService categoryService, IUnitOfWork uow)
            : base(uow)
        {
            _categoryService = categoryService;
        }


        public CategoryViewModel Add(CategoryViewModel obj)
        {
            var category = Mapper.Map<CategoryViewModel, Category>(obj);
            BeginTransaction();
            _categoryService.Add(category);
            Commit();
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
            var category = Mapper.Map<CategoryViewModel, Category>(obj);

            BeginTransaction();
            _categoryService.Update(category);
            Commit();

            return obj;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _categoryService.Remove(id);
            Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _categoryService.Dispose();
        }
    }
}