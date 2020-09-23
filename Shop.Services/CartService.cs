using Shop.Core.Contracts;
using Shop.Core.Models;
using Shop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shop.Services
{
    public class CartService : ICartService
    {
        IRepository<Watch> watchContext;
        IRepository<Cart> cartContext;

        public const string CartSessionName = "shopCart";

        public CartService(IRepository<Watch> WatchContext, IRepository<Cart> CartContext)
        {
            this.watchContext = WatchContext;
            this.cartContext = CartContext;
        }

        private Cart GetCart(HttpContextBase httpContext, bool createIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(CartSessionName);
            Cart cart = new Cart();

            if (cookie != null)
            {
                string cartId = cookie.Value;
                if (!string.IsNullOrEmpty(cartId))
                {
                    cart = cartContext.Find(cartId);
                }
                else
                {
                    if (createIfNull)
                    {
                        cart = CreateNewCart(httpContext);
                    }
                }
            }
            else
            {
                if (createIfNull)
                {
                    cart = CreateNewCart(httpContext);
                }
            }

            return cart;
        }

        private Cart CreateNewCart(HttpContextBase httpContext)
        {
            Cart cart = new Cart();
            cartContext.Insert(cart);
            cartContext.Commit();

            HttpCookie cookie = new HttpCookie(CartSessionName);
            cookie.Value = cart.Id;
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);
            return cart;
        }

        public void AddToCart(HttpContextBase httpContext, string WatchtId)
        {
            Cart cart = GetCart(httpContext, true);
            CartItem item = cart.CartItems.FirstOrDefault(i => i.WatchId == WatchtId);

            if(item == null)
            {
                item = new CartItem() {
                    CartId = cart.Id,
                    WatchId = WatchtId,
                    Quantity = 1
                };

                cart.CartItems.Add(item);
            }
            else
            {
                item.Quantity++;
            }

            cartContext.Commit();
        }

        public void RemoveFromCart(HttpContextBase httpContext, string itemId)
        {
            Cart cart = GetCart(httpContext, true);
            CartItem item = cart.CartItems.FirstOrDefault(i => i.Id == itemId);

            if(item != null)
            {
                cart.CartItems.Remove(item);
                cartContext.Commit();
            }
        }

        public List<CartItemViewModel> GetCartItems(HttpContextBase httpContext)
        {
            Cart cart = GetCart(httpContext, false);

            if(cart != null)
            {
                var result = (from b in cart.CartItems
                              join w in watchContext.Collection() on b.WatchId equals w.Id
                              select new CartItemViewModel()
                              {
                                  Id = b.Id,
                                  Quantity = b.Quantity,
                                  WatchName = w.Name,
                                  WatchPrice = w.Price,
                                  Image = w.Image
                              }).ToList();
                return result;
            }
            else
            {
                return new List<CartItemViewModel>();
            }
        }

        public CartSummaryViewModel GetCartSummary(HttpContextBase httpContext)
        {
            Cart cart = GetCart(httpContext, false);
            CartSummaryViewModel viewModel = new CartSummaryViewModel();
            if (cart != null)
            {
                int? cartCount = (from b in cart.CartItems
                                  select b.Quantity).Sum(); 

                decimal? cartTotal = (from b in cart.CartItems
                                      join w in watchContext.Collection() on b.WatchId equals w.Id
                                      select b.Quantity * w.Price).Sum();

                viewModel.CartCount = cartCount ?? 0;
                viewModel.CartTotal = cartTotal ?? decimal.Zero;
                return viewModel;
            }
            else
            {
                return viewModel;
            }
        }

        public void ClearCart(HttpContextBase httpContext)
        {
            Cart cart = GetCart(httpContext, false);
            cart.CartItems.Clear();
            cartContext.Commit();
        }
    }
}
