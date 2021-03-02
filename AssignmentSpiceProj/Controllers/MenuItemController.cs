using Spice.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Spice.DomainModel;
using AssignmentSpiceProj.Global;

namespace AssignmentSpiceProj.Controllers
{
    public class MenuItemController : Controller
    {
        SpiceDbContext db = new SpiceDbContext();
        // GET: MenuItem
        public ActionResult Index()
        {
            //GlobalVariable.CartCount = 0;
            if (User.Identity.IsAuthenticated)
                GlobalVariable.CartCount = db.ShoppingCarts.Where(u => u.ApplicationUserId == User.Identity.Name).ToList().Count;
            var menuItem = db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).ToList();
            return View(menuItem);
        }
        public ActionResult Create()
        {
            return View();
        }
        //POST - CREATE
        [HttpPost]
        public ActionResult Create(MenuItem menuItem)
        {
            if(Request.Files.Count >= 1)
            {
                var photo = Request.Files[0];
                var imgBytes = new Byte[photo.ContentLength - 1];
                photo.InputStream.Read(imgBytes, 0, photo.ContentLength - 1);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                menuItem.Image = base64String;
            }

            db.MenuItems.Add(menuItem);
            db.SaveChanges();
            return RedirectToAction("Index");
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
        public ActionResult Delete(int? id)
        {
            var deleteCat = db.MenuItems.Where(e => e.Id == id).FirstOrDefault();
            db.MenuItems.Remove(deleteCat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}