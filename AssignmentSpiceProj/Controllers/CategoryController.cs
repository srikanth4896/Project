using Spice.DataLayer;
using Spice.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentSpiceProj.Controllers
{
   
    public class CategoryController : Controller
    {
        SpiceDbContext db = new SpiceDbContext();
        // GET: Category
        public ActionResult Index()
        {
            var category = db.Categories.ToList();
            return View(category);
        }
        public ActionResult Create()
        {
            return View();
        }


        //POST - CREATE
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //if valid
                db.Categories.Add(category);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(category);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var emp = db.Categories.SingleOrDefault(e => e.Id == id);
            //var category = db.Category.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);

        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }
            else
            {
                var updatedRes = db.Categories.Where(e => e.Id == category.Id).FirstOrDefault();
                updatedRes.Name = category.Name;
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int? id)
        {
            var deleteCat = db.Categories.Where(e => e.Id == id).FirstOrDefault();
            db.Categories.Remove(deleteCat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }
    }
}