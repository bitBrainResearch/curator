using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using curator.Models;

namespace curator.Controllers
{
    public class DiscussionPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DiscussionPosts
        public ActionResult Index()
        {
            var discussionPosts = db.DiscussionPosts.Include(d => d.CodeSnippet);
            return View(discussionPosts.ToList());
        }

        // GET: DiscussionPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscussionPost discussionPost = db.DiscussionPosts.Find(id);
            if (discussionPost == null)
            {
                return HttpNotFound();
            }
            return View(discussionPost);
        }

        // GET: DiscussionPosts/Create
        public ActionResult Create()
        {
            ViewBag.CodeSnippetID = new SelectList(db.CodeSnippets, "CodeSnippetID", "Title");
            return View();
        }

        // POST: DiscussionPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiscussionPostID,CodeSnippetID,UserName,Subject,BodyText,DateCreated,DateEdited")] DiscussionPost discussionPost)
        {
            if (ModelState.IsValid)
            {
                db.DiscussionPosts.Add(discussionPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodeSnippetID = new SelectList(db.CodeSnippets, "CodeSnippetID", "Title", discussionPost.CodeSnippetID);
            return View(discussionPost);
        }

        // GET: DiscussionPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscussionPost discussionPost = db.DiscussionPosts.Find(id);
            if (discussionPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodeSnippetID = new SelectList(db.CodeSnippets, "CodeSnippetID", "Title", discussionPost.CodeSnippetID);
            return View(discussionPost);
        }

        // POST: DiscussionPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiscussionPostID,CodeSnippetID,UserName,Subject,BodyText,DateCreated,DateEdited")] DiscussionPost discussionPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discussionPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodeSnippetID = new SelectList(db.CodeSnippets, "CodeSnippetID", "Title", discussionPost.CodeSnippetID);
            return View(discussionPost);
        }

        // GET: DiscussionPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiscussionPost discussionPost = db.DiscussionPosts.Find(id);
            if (discussionPost == null)
            {
                return HttpNotFound();
            }
            return View(discussionPost);
        }

        // POST: DiscussionPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiscussionPost discussionPost = db.DiscussionPosts.Find(id);
            db.DiscussionPosts.Remove(discussionPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
