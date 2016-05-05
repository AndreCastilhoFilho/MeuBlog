using AndreFilho.Blog.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreFilho.Blog.Domain.Entities;
using AndreFilho.Blog.Domain.Interfaces.Repository;

namespace AndreFilho.Blog.Domain.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category Add(Category obj)
        {
            return _categoryRepository.Add(obj);
        }

        public void Dispose()
        {
            _categoryRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(Guid id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Remove(Guid id)
        {
            _categoryRepository.Remove(id);
        }

        public Category Update(Category obj)
        {
            return _categoryRepository.Update(obj);
        }
    }
}
