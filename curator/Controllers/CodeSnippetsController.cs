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
    
    public class CodeSnippetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CodeSnippets
        [Route("CodeSnippets/Index")]
        public ActionResult Index()
        {
            return View(db.CodeSnippets.ToList());
        }



        // GET: CodeSnippets/Details/5
        [Route("snippet/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeSnippet codeSnippet = db.CodeSnippets.Find(id);
            if (codeSnippet == null)
            {
                return HttpNotFound();
            }
            return View(codeSnippet);
        }

        // GET: CodeSnippets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CodeSnippets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SnippetID,Title,Description,Code")] CodeSnippet codeSnippet)
        {
            if (ModelState.IsValid)
            {
                db.CodeSnippets.Add(codeSnippet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(codeSnippet);
        }

        // GET: CodeSnippets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeSnippet codeSnippet = db.CodeSnippets.Find(id);
            if (codeSnippet == null)
            {
                return HttpNotFound();
            }
            return View(codeSnippet);
        }

        // POST: CodeSnippets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SnippetID,Title,Description,Code")] CodeSnippet codeSnippet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(codeSnippet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(codeSnippet);
        }

        // GET: CodeSnippets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodeSnippet codeSnippet = db.CodeSnippets.Find(id);
            if (codeSnippet == null)
            {
                return HttpNotFound();
            }
            return View(codeSnippet);
        }

        // POST: CodeSnippets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CodeSnippet codeSnippet = db.CodeSnippets.Find(id);
            db.CodeSnippets.Remove(codeSnippet);
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
