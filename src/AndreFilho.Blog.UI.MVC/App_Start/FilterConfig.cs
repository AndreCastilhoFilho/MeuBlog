using System.Web;
using System.Web.Mvc;
using AndreFilho.Blog.Infra.CrossCutting.MvcFilters;

namespace AndreFilho.Blog.UI.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
