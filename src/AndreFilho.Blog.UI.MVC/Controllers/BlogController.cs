using System;
using System.Net;
using AndreFilho.Blog.Application;
using PagedList;
using System.Web.Mvc;
using AndreFilho.Blog.Application.ViewModel;

namespace AndreFilho.Blog.UI.MVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogAppService _blogService;
        private const  int pageSize = 5;

        public BlogController(IBlogAppService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
          var posts = _blogService.GetAllPosts().ToPagedList(1, pageSize);
          
            return View(posts);
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult PageListPost(int? page, string sortOrder, string searchString, string searchCategory, string searchTag)
        {
            ViewBag.CurrentSearchCategory = searchCategory;
            ViewBag.searchString = searchString;
            int pageNumber = (page ?? 1);

            var posts = _blogService.GetPostsBySearchCategoryAndTag(searchString, searchCategory, searchTag).ToPagedList(pageNumber, pageSize);

            return View("Index",posts);
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult SearchPosts(string searchString)
        {
            ViewBag.searchString = searchString;
            TempData["searchString"] = searchString;
            var posts = _blogService.GetPostsBySearch(searchString).ToPagedList(1, pageSize);

            return View("Index", posts);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Category(string category)
        {
          
            var posts = _blogService.PostsByCategory(category).ToPagedList(1, pageSize);


            return View("Index",posts);
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
            var model = _blogService.GetPostByUrlSlug(slug);
            return View(model);
        }


        // GET: Posts
        public ActionResult CategoriesAndTags()
        {
            var categoriesAndTags =  new CategoriesAndTagsViewModel();

            categoriesAndTags.Categories = _blogService.GetAllCategories();
            categoriesAndTags.Tags = _blogService.GetAllTags();

            return View(categoriesAndTags);
        }
        
        [Route("excluir-tag/{id:guid}")]
        public ActionResult DeleteTag(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tagViewModel = _blogService.GetTagById(id.Value);

            return PartialView("_DeleteTag", tagViewModel);

        }

        [Route("excluir-tag/{id:guid}")]
        [HttpPost, ActionName("DeleteTag")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTagConfirmed(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _blogService.RemoveTag(id);

            string url = Url.Action("ListTags", "Blog");
            return Json(new { success = true, url = url });
            
        }
        [Route("adicionar-tag")]
        public ActionResult AddTag()
        {
            return PartialView("_AddTag");
        }
        [Route("adicionar-tag")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTag(TagViewModel tagViewModel)
        {
            if (ModelState.IsValid)
            {
                _blogService.AddTag(tagViewModel);
                string url = Url.Action("ListTags", "Blog");
                return Json(new { success = true, url = url });
            }
            return PartialView("_AddTag", tagViewModel);
        }


        public ActionResult ListTags()
        {
            var tags = _blogService.GetAllTags();
            return PartialView("_TagList", tags);

        }


        [Route("adicionar-categoria")]
        public ActionResult AddCategory()
        {
            return PartialView("_AddCategory");
        }
        [Route("adicionar-categoria")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _blogService.AddCategory(categoryViewModel);
                string url = Url.Action("ListCategories", "Blog");
                return Json(new { success = true, url = url });
            }
            return PartialView("_AddCategory", categoryViewModel);
        }


        public ActionResult ListCategories()
        {
            var categories = _blogService.GetAllCategories();
            return PartialView("_CategoryList", categories);

        }


        [Route("excluir-category/{id:guid}")]
        public ActionResult DeleteCategory(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoryViewModel = _blogService.GetCategoryById(id.Value);

            return PartialView("_DeleteCategory", categoryViewModel);

        }

        [Route("excluir-category/{id:guid}")]
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategoryConfirmed(Guid id)
        {
         
            _blogService.RemoveCategory(id);

            string url = Url.Action("ListCategories", "Blog");
            return Json(new { success = true, url = url });

        }

    }

    
}