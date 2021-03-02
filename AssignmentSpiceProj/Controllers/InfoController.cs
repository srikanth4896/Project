using Spice.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AssignmentSpiceProj.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        SpiceDbContext db = new SpiceDbContext();
        // GET: List
        public ActionResult Index()
        {
            var menuItem = db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).ToList();
            return View(menuItem);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return HttpNotFound();
            }

            return View(menuItem);
        }
        public ActionResult Apetizer()
        {

            var ap = from p in db.MenuItems
                     where p.CategoryId == 1
                     select p;
            return View(ap);
        }
        public ActionResult MainCourse()
        {
            var ap = from p in db.MenuItems
                     where p.CategoryId == 2
                     select p;
            return View(ap);
        }
        public ActionResult Beverages()
        {

            var ap = from p in db.MenuItems
                     where p.CategoryId == 4
                     select p;
            return View(ap);
        }
        public ActionResult Dessert()
        {

            var ap = from p in db.MenuItems
                     where p.CategoryId == 3
                     select p;
            return View(ap);
        }

    }
}
    
