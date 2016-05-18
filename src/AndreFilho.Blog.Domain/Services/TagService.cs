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
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }


        public Tag Add(Tag obj)
        {
            return _tagRepository.Add(obj);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _tagRepository.Dispose();
        }

        public IEnumerable<Tag> GetAll()
        {
            return _tagRepository.GetAll();
        }

        public Tag GetById(Guid id)
        {
            return _tagRepository.GetById(id);
        }

        public void Remove(Guid id)
        {
            _tagRepository.Remove(id);
        }

        public Tag Update(Tag obj)
        {
            return _tagRepository.Update(obj);
        }
    }
}
