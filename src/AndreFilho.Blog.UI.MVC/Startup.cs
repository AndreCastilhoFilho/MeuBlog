using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AndreFilho.Blog.UI.MVC.Startup))]
namespace AndreFilho.Blog.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
