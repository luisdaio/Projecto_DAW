using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ViewModels
{
    public class CartItemViewModel
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public string WatchName { get; set; }
        public decimal WatchPrice { get; set; }
        public string Image { get; set; }

    }
}
