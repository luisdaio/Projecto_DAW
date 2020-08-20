using Shop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class CartController : Controller
    {
        ICartService CartService;

        public CartController(ICartService CartService)
        {
            this.CartService = CartService;
        }


        // GET: Cart
        public ActionResult Index()
        {
            var model = CartService.GetCartItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToCart(string Id)
        {
            CartService.AddToCart(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(string Id)
        {
            CartService.RemoveFromCart(this.HttpContext, Id);
            return RedirectToAction("Index");
        }       
        
        public PartialViewResult CartSummary()
        {
            var cartSummary = CartService.GetCartSummary(this.HttpContext);
            return PartialView(cartSummary);
        }
    }
}