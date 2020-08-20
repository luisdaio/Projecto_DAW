using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ViewModels
{
    public class CartSummaryViewModel
    {
        public int CartCount { get; set; }
        public decimal CartTotal { get; set; }

        public CartSummaryViewModel(int CartCount = 0, decimal CartTotal = 0)
        {
            this.CartCount = CartCount;
            this.CartTotal = CartTotal;
        }
    }
}
