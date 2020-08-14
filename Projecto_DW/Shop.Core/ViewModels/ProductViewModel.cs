using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ViewModels
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        public IEnumerable<ProductCategory> categories { get; set; }
    }
}
