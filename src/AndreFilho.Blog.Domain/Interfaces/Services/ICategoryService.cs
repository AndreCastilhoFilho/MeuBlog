using AndreFilho.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreFilho.Blog.Domain.Interfaces.Services
{
   public interface ICategoryService : IDisposable
    {
        Category Add(Category obj);
        Category GetById(Guid id);
        IEnumerable<Category> GetAll();
        Category Update(Category obj);
        void Remove(Guid id);

    }
}
