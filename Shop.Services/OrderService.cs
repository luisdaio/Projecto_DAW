using Shop.Core.Contracts;
using Shop.Core.Models;
using Shop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class OrderService : IOrderService
    {
        IRepository<Order> orderContext { get; set; }

        public OrderService(IRepository<Order> orderContext)
        {
            this.orderContext = orderContext;
        }

        public void CreateOrder(Order baseOrder, List<CartItemViewModel> cartItems)
        {
            foreach (var item in cartItems)
            {
                baseOrder.OrderItems.Add(new OrderItem() { 
                    ProductId = item.Id,
                    Image = item.Image,
                    ProductPrice = item.ProductPrice,
                    Quantity = item.Quantity
                });            
            }

            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }
    }
}
