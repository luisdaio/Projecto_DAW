﻿using Shop.Core.Models;
using Shop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Contracts
{
    public interface IOrderService
    {
        void CreateOrder(Order baseOrder, List<CartItemViewModel> cartItems);

        List<Order> GetOrdersList();

        Order GetOrder(string Id);

        void UpdateOrder(Order updatedOrder);
    }
}