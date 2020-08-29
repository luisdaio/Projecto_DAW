using Shop.Core.Contracts;
using Shop.Core.Models;
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
        IOrderService OrderService;

        public CartController(ICartService CartService, IOrderService OrderService)
        {
            this.CartService = CartService;
            this.OrderService = OrderService;
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

        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(Order Order)
        {
            if(!ModelState.IsValid)
            {
                return View(Order);
            }
            else
            {
                var cartItems = CartService.GetCartItems(this.HttpContext);
                Order.OrderStatus = "Order Created";

                // Payment Process;

                Order.OrderStatus = "Order Processed";
                OrderService.CreateOrder(Order, cartItems);
                CartService.ClearCart(this.HttpContext);
                return RedirectToAction("ThankYou", new { OrderId = Order.Id });
            }
        }

        public ActionResult ThankYou(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }
    }
}