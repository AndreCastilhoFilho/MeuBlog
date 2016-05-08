using AndreFilho.Blog.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreFilho.Blog.Application.Interfaces
{
  public   interface IPostAppService : IDisposable
    {

        PostViewModel Add(PostViewModel obj);
        PostViewModel GetById(Guid id);
        IEnumerable<PostViewModel> GetAll();
        PostViewModel Update(PostViewModel obj);
        IEnumerable<TagViewModel> getAllTags();
        void Remove(Guid id);

    }
}
