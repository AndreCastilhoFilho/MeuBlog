using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Entities;
using AutoMapper;


namespace AndreFilho.Blog.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Post, BlogViewModel>();
            CreateMap<Post, PostViewModel>();
            CreateMap<Tag, TagViewModel>();
            CreateMap<Category, CategoryViewModel>();


        }
    }
}