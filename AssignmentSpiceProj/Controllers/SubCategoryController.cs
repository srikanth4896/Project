using Spice.DataLayer;
using Spice.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentSpiceProj.Controllers
{
    public class SubCategoryController : Controller
    {
        SpiceDbContext db = new SpiceDbContext();
        // GET: SubCategory
        public ActionResult Index()
        {
            var SubCategory = db.SubCategories.ToList();
            return View(SubCategory);
        }
        public ActionResult Create()
        {
            return View();
        }


        //POST - CREATE
        [HttpPost]
        public ActionResult Create(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                //if valid
                db.SubCategories.Add(subCategory);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(subCategory);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var Subcategory = db.SubCategories.Find(id);
            if (Subcategory == null)
            {
                return HttpNotFound();
            }

            return View(Subcategory);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var sub = db.SubCategories.SingleOrDefault(e => e.Id == id);

            if (sub == null)
            {
                return HttpNotFound();
            }
            return View(sub);

        }

        [HttpPost]
        public ActionResult Edit(SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }
            else
            {
                var updatedRes = db.SubCategories.Where(e => e.Id == subCategory.Id).FirstOrDefault();
                updatedRes.Name = subCategory.Name;
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int? id)
        {
            var deleteCat = db.SubCategories.Where(e => e.Id == id).FirstOrDefault();
            db.SubCategories.Remove(deleteCat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}