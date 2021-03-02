using Microsoft.AspNet.Identity;
using Spice.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Spice.DomainModel;
using AssignmentSpiceProj.Global;
using AssignmentSpiceProj.Models.ViewModels;

namespace AssignmentSpiceProj.Controllers
{
    public class ShoppingCartController : Controller
    {
        SpiceDbContext db = new SpiceDbContext();

        // GET: ShoppingCart
        
        public ActionResult AddtoCart(int a,ShoppingCart shoppingCart)
        {
            
            ViewBag.uId = User.Identity.GetUserId();
            string auId = ViewBag.uId;
            var cartItems = db.ShoppingCarts.ToList().Where(e => e.ApplicationUserId == auId && e.MenuItemId == a).FirstOrDefault();
            
            if (cartItems == null)
            {
                db.ShoppingCarts.Add(shoppingCart);
                db.SaveChanges();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }

            else
            {
                cartItems.Count = cartItems.Count + 1;
                db.SaveChanges();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }
            GlobalVariable.CartCount = GlobalVariable.CartCount + 1;
            //return View();
            return RedirectToAction("Cart"); ;
        }

        public ActionResult Cart()
        {
            ViewBag.Message = "Items in your cart";
            ViewBag.uId = User.Identity.GetUserId();
            string auId = ViewBag.uId;
            var cartItem = db.ShoppingCarts.Where(e => e.ApplicationUserId == auId).ToList();
            return View(cartItem);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            ViewBag.user = User.Identity.GetUserId();
            var OneItem = db.MenuItems.Where(e => e.Id == id).FirstOrDefault();
            
            return View(OneItem);
        }
        public ActionResult RemoveCart(int? id)
        {
            var delete = db.ShoppingCarts.Where(e => e.Id == id).FirstOrDefault();
            db.ShoppingCarts.Remove(delete);
            db.SaveChanges();
            //Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            GlobalVariable.CartCount = GlobalVariable.CartCount - 1;
            return RedirectToAction("Cart");
        }

        public ActionResult PlusItems(int cartId)
        {
            var cart = db.ShoppingCarts.FirstOrDefault(e => e.Id == cartId);
            cart.Count += 1;
           
            db.SaveChanges();
            return RedirectToAction("Cart");

        }

        public ActionResult MinusItems(int cartId)
        {
            
            var cart = db.ShoppingCarts.FirstOrDefault(e => e.Id == cartId);
            cart.Count -= 1;
            if (cart.Count > 0)
            {
               // Session["cart"] = (int)Session["cart"] - 1;
                db.SaveChanges();
            }
            return RedirectToAction("Cart");

        }
        public ActionResult OrderSummary()
        {
            ViewBag.uId = User.Identity.GetUserId();
            string auId = ViewBag.uId;
            var shoppingcart = db.ShoppingCarts.Where(e => e.ApplicationUserId == auId).ToList();
            // var cartItems = GetCartItems(auId);
            var viewModel = new MenuItemViewModel
            {
                ShoppingCarts = shoppingcart
            };
            return View(viewModel);

        }

    }
}