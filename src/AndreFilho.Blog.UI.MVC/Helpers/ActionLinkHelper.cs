
using AndreFilho.Blog.Application.ViewModel;
using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AndreFilho.Blog.UI.MVC.Helpers
{
    public static class ActionLinkHelper
    {
        public static MvcHtmlString CategoryLink(this HtmlHelper helper, CategoryViewModel category)
        {
            return helper.ActionLink(category.Name, "Category", "Blog", new { category = category.UrlSlug }, new { title = String.Format("Veja todos os posts sobre {0}", category.Name) });
        }


    }
}