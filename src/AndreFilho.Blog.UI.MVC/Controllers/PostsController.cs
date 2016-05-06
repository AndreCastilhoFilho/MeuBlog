using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AndreFilho.Blog.Application.ViewModel;
using AndreFilho.Blog.UI.MVC.Models;
using AndreFilho.Blog.Application.Interfaces;

namespace AndreFilho.Blog.UI.MVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostAppService _postAppService;

        public PostsController(IPostAppService postService)
        {
            _postAppService = postService;
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

                return RedirectToAction("Index", "Blog", null);
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
    }
}
