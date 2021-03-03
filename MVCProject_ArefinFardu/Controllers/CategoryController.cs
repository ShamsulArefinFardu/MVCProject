using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;


using MVCProject_ArefinFardu.Models;
using MVCProject_ArefinFardu.Models.ViewModel;

using AutoMapper;     
using PagedList;
using System.Data.Entity;

namespace MVCProject_ArefinFardu.Controllers
{
    public class CategoryController : Controller
    {
        private MVCProject_ArefinFarduEntities db = new MVCProject_ArefinFarduEntities();

        // GET: Category


        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var categories = from t in db.Categories
                           select t;
            if (!string.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(t => t.CategoryName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    categories = categories.OrderByDescending(t => t.CategoryName);
                    break;
                default:
                    categories = categories.OrderBy(t => t.CategoryName);
                    break;
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(categories.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = db.Categories.Single(t => t.CategoryId == id);
            var category = Mapper.Map<Category, CategoryVM>(query);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(categoryVM);
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryVM);
        }

        // GET: Edit
        public ActionResult Edit(int? id)
        {
            var query = db.Categories.Single(t => t.CategoryId == id);
            var category = Mapper.Map<Category, CategoryVM>(query);
            return View(category);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(categoryVM);
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryVM);
        }

        // GET: Delete

        public ActionResult Delete(int? id)
        {
            var query = db.Categories.Single(t => t.CategoryId == id);
            var category = Mapper.Map<Category, CategoryVM>(query);
            return View(category);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, CategoryVM categoryVM)
        {
            var query = db.Categories.Single(t => t.CategoryId == id);
            var category = Mapper.Map<Category, CategoryVM>(query);
            db.Categories.Remove(query);  // 
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