using AndreFilho.Blog.Domain.Entities;
using System;
using System.Collections.Generic;


namespace AndreFilho.Blog.Domain.Interfaces.Services
{
  public  interface ITagService : IDisposable
    {
        Tag Add(Tag obj);
        Tag GetById(Guid id);
        IEnumerable<Tag> GetAll();
        Tag Update(Tag obj);
        void Remove(Guid id);
    }
}
