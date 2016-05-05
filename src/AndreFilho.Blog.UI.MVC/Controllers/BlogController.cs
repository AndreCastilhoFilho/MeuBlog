using AndreFilho.Blog.Application;
using PagedList;
using System.Web.Mvc;

namespace AndreFilho.Blog.UI.MVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogAppService _blogService;
        private const  int pageSize = 10;

        public BlogController(IBlogAppService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(int? page, string sortOrder, string searchString, string[] searchCategory, string[] searchTag)
        {
            int pageNumber = (page ?? 1);

            var posts = _blogService.GetAll().ToPagedList(pageNumber, pageSize);

           // return PartialView("_Posts",posts);

            return View(posts);
        }

        [ChildActionOnly]
        public PartialViewResult Sidebar()
        {
            var sideBar = _blogService.GetSideBar();
            return PartialView("_Sidebar", sideBar);
        }

        [HttpGet]
        [Route("Post/{slug}")]
        public ActionResult Post(string slug)
        {
            var model = _blogService.getPostByUrlSlugslug(slug);
            return View(model);
        }



    }
}