﻿
using AndreFilho.Blog.Application;
using AndreFilho.Blog.Application.Interfaces;
using AndreFilho.Blog.Application.Services;
using AndreFilho.Blog.Domain.Interfaces.Repository;
using AndreFilho.Blog.Domain.Interfaces.Services;
using AndreFilho.Blog.Domain.Services;
using AndreFilho.Blog.Infra.CrossCutting.Identity.Configuration;
using AndreFilho.Blog.Infra.CrossCutting.Identity.Context;
using AndreFilho.Blog.Infra.CrossCutting.Identity.Model;
using AndreFilho.Blog.Infra.Data.Context;
using AndreFilho.Blog.Infra.Data.Interfaces;
using AndreFilho.Blog.Infra.Data.Repository;
using AndreFilho.Blog.Infra.Data.UoW;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;

namespace AndreFilho.Blog.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // APP
            container.Register<IBlogAppService, BlogAppService>(Lifestyle.Scoped);
            container.Register<IPostAppService, PostAppService>(Lifestyle.Scoped);
            container.Register<IBlogService, BlogService>(Lifestyle.Scoped);

            // Domain
            container.Register<IPostService, PostService>(Lifestyle.Scoped);
            container.Register<ICategoryService, CategoryService>(Lifestyle.Scoped);
            container.Register<ITagService, TagService>(Lifestyle.Scoped);

            // Dados
            container.Register<IPostRepository, PostRepository>(Lifestyle.Scoped);
            container.Register<ICategoryRepository, CategoryRepository>(Lifestyle.Scoped);
            container.Register<ITagRepository, TagRepository>(Lifestyle.Scoped);

            //container.Register(typeof(IRepository<>), typeof(Repository<>));
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<BlogContext>(Lifestyle.Scoped);

            //Identity
            container.RegisterPerWebRequest<ApplicationDbContext>();
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.RegisterPerWebRequest<IRoleStore <IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();

          
        }
    }
}