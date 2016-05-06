using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.Domain.Entities;
using AutoMapper;


namespace AndreFilho.Blog.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<PostViewModel, Post>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<TagViewModel, Tag>();
        }
    }
}