using AndreFilho.Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Interfaces.Services;
using AutoMapper;
using AndreFilho.Blog.Domain.Entities;
using AndreFilho.Blog.Domain.Interfaces.Repository;

namespace AndreFilho.Blog.Application.Services
{
    public class PostAppService : IPostAppService
    {
        private readonly IPostService _postService;
        private readonly ITagRepository _tagRepository;


        public PostAppService(IPostService postService, ITagRepository tagRepository)
        {
            _postService = postService;
            _tagRepository = tagRepository;
        }

        public PostViewModel Add(PostViewModel obj)
        {
            var post = Mapper.Map<PostViewModel, Post>(obj);
            post.Published = true;

            _postService.Add(post);
            return obj;
            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _postService.Dispose();
        }

        public IEnumerable<PostViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(_postService.GetAll());
        }

        public PostViewModel GetById(Guid id)
        {
            return Mapper.Map<Post, PostViewModel>(_postService.GetById(id));
        }

        public IEnumerable<TagViewModel> getAllTags()
        {

            return Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(_tagRepository.GetAll());

        }

        public void Remove(Guid id)
        {
            _postService.Remove(id);
        }

        public PostViewModel Update(PostViewModel obj)
        {
            var post = Mapper.Map<PostViewModel, Post>(obj);
            _postService.Update(post);
            return obj;
        }
    }
}
