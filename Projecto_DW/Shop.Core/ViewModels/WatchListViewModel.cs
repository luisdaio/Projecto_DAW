using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ViewModels
{
    public class WatchListViewModel
    {
        public IEnumerable<Watch> Watches { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}
