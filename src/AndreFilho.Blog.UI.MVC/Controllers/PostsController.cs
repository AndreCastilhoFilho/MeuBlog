using System;

using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AndreFilho.Blog.Application.ViewModel;

using AndreFilho.Blog.Application.Interfaces;

namespace AndreFilho.Blog.UI.MVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostAppService _postAppService;
        private readonly ICategoryAppService _categoryAppService;

        public PostsController(IPostAppService postService, ICategoryAppService categoryService)
        {
            _postAppService = postService;
            _categoryAppService = categoryService;
        }

        // GET: Posts
        public ActionResult Index()
        {
            return View(_postAppService.GetAll());
        }

        // GET: Posts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post = _postAppService.GetById(id.Value);

            if (post == null)
            {
                return HttpNotFound();
            }
            
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = 
                _categoryAppService.GetAll().Select(p=> new SelectListItem
            {
                Text = p.Name, Value = p.CategoryId.ToString()
            });


            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Title,ShortDescription,Description,Meta,SlugUrl,Published,PostedOn,Modified,CategoryId,Category")] PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {              
                postViewModel = _postAppService.Add(postViewModel);
            
                return RedirectToAction("Edit", "Posts", new { id = postViewModel.PostId } );
            }

            return View(postViewModel);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(Guid? id)
        {
           if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postViewModel = _postAppService.GetById(id.Value);

            postViewModel.Categories = _categoryAppService.GetAll();
            postViewModel.TagList = _postAppService.getAllTags();
            if (postViewModel == null)
            {
                return HttpNotFound();
            }
            return View(postViewModel);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,Title,ShortDescription,Description,Meta,SlugUrl,Published,PostedOn,Modified,CategoryId,Category")] PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                _postAppService.Update(postViewModel);               
                return RedirectToAction("Index");
            }
            return View(postViewModel);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postViewModel = _postAppService.GetById(id.Value);
            if (postViewModel == null)
            {
                return HttpNotFound();
            }
            return View(postViewModel);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _postAppService.Remove(id);
                  
                return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _postAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        
        public ActionResult DeletarPostTag(Guid? idPost, Guid? idTag)
        {
            if (idPost == null || idTag == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                       
            _postAppService.RemoveTagFromPost(idTag.Value, idPost.Value);

             var postViewModel = _postAppService.GetById(idPost.Value);

            //todo retornar Json / tornar metodo AJAX

            return PartialView("_TagList", postViewModel);
        }

        public ActionResult AddTagToPost(Guid? idPost, Guid? idTag)
        {
            if (idPost == null || idTag == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          var  postViewModel = _postAppService.AddTagToPost(idTag.Value, idPost.Value);

            return PartialView("_TagList", postViewModel);

        }
            
    }
}
