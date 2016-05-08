using System;
using System.Collections.Generic;
using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Entities;

namespace AndreFilho.Blog.Application.Interfaces
{
    public interface ICategoryAppService : IDisposable
    {
        CategoryViewModel Add(CategoryViewModel obj);
        CategoryViewModel GetById(Guid id);
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel Update(CategoryViewModel obj);
        void Remove(Guid id);
    }
}