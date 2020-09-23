using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class OrderItem : BaseEntity
    {
        public string OrderId { get; set; }
        public string WatchId { get; set; }
        public string WatchName { get; set; }
        public decimal WatchPrice { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}
