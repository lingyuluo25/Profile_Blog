using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BlogMVCProject.Models;
using BlogMVCProject.ViewModels;
using PagedList;

namespace BlogMVCProject.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Articles
        public ActionResult Index(string category, string search, string sortBy, int? page)
        {
            
            ArticleIndexViewModel viewModel = new ArticleIndexViewModel();
            var articles = db.Articles.Include(a => a.Category);

            
            if (!string.IsNullOrEmpty(search))
            {
                articles = articles.Where(a => a.Title.Contains(search) ||
                                               a.Content.Contains(search) ||
                                               a.Category.Name.Contains(search));
                viewModel.Search = search; 
            }

           
            viewModel.CatsWithCount = from matchingArticles in articles
                                      where matchingArticles.CategoryID != null
                                      group matchingArticles by matchingArticles.Category.Name into catGroup
                                      select new CategoryWithCount()
                                      {
                                          CategoryName = catGroup.Key,
                                          ArticleCount = catGroup.Count()
                                      };

            
            if (!string.IsNullOrEmpty(category))
            {
                articles = articles.Where(a => a.Category.Name == category);
                viewModel.Category = category;
            }

            
            switch (sortBy)
            {
                case "date_oldest":
                    articles = articles.OrderBy(a => a.PublishedDate);
                    break;
                case "date_newest":
                    articles = articles.OrderByDescending(a => a.PublishedDate);
                    break;
                case "title_asc":
                    articles = articles.OrderBy(a => a.Title);
                    break;
                case "title_desc":
                    articles = articles.OrderByDescending(a => a.Title);
                    break;
                default:
                    articles = articles.OrderBy(a => a.Title);
                    break;
            }

            
            viewModel.SortBy = sortBy;
            viewModel.Sorts = new Dictionary<string, string>
            {
                {"Date (Oldest to Newest)", "date_oldest" },
                {"Date (Newest to Oldest)", "date_newest" },
                {"Title (A - Z)", "title_asc" },
                {"Title (Z - A)", "title_desc" }
            };

            
            const int PageItems = 3;
            int currentPage = (page ?? 1);
            viewModel.Articles = articles.ToPagedList(currentPage, PageItems);

            
            return View(viewModel);
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Content,PublishedDate,CategoryID")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", article.CategoryID);
            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", article.CategoryID);
            return View(article);
        }

        // POST: Articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Content,PublishedDate,CategoryID")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", article.CategoryID);
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
