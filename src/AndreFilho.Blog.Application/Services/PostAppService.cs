﻿using AndreFilho.Blog.Application.Interfaces;
using System;
using System.Collections.Generic;
using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Interfaces.Services;
using AutoMapper;
using AndreFilho.Blog.Domain.Entities;
using AndreFilho.Blog.Domain.Interfaces.Repository;
using AndreFilho.Blog.Infra.Data.Interfaces;

namespace AndreFilho.Blog.Application.Services
{
    public class PostAppService : ApplicationService, IPostAppService
    {
        private readonly IPostService _postService;
        private readonly ITagService _tagService;


        public PostAppService(IPostService postService, ITagService tagService, IUnitOfWork uow) :
            base(uow)
        {
            _postService = postService;
            _tagService = tagService;
        }

        public PostViewModel Add(PostViewModel obj)
        {
            var post = Mapper.Map<PostViewModel, Post>(obj);
            post.Published = true;

            BeginTransaction();
            //todo validar objeto
            _postService.Add(post);
            Commit();
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

            return Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(_tagService.GetAll());

        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _postService.Remove(id);
            Commit();
        }

        public PostViewModel Update(PostViewModel obj)
        {
            var post = Mapper.Map<PostViewModel, Post>(obj);
            BeginTransaction();
            _postService.Update(post);
            Commit();
            return obj;
        }

        public PostViewModel RemoveTagFromPost(Guid tagId, Guid PostId)
        {
            BeginTransaction();
            var postViewModel = Mapper.Map<Post, PostViewModel>(_postService.RemoveTagFromPost(tagId, PostId));
            Commit();

            return postViewModel;

        }

        public PostViewModel AddTagToPost(Guid TagId, Guid PostId)
        {
            BeginTransaction();
            var postViewModel =  Mapper.Map<Post, PostViewModel>(_postService.AddTagToPost(TagId, PostId));
            Commit();

            return postViewModel;
        }
    }
}
