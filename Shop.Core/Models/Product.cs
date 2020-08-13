using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class Product
    {
        string Id { get; set; }
        [StringLength(20)]
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        string Category { get; set; }
        string Image { get; set; }

        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
