using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class Product : BaseEntity
    {
        /// <summary>
        /// Product Name.
        /// </summary>
        [StringLength(20)]
        [DisplayName("Product Name")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Product description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Product price.
        /// </summary>
        [Required]
        [Range(0, 1000000)]
        public decimal Price { get; set; }

        /// <summary>
        /// Product category allowing grouping and filtering.
        /// </summary>
        [Required]
        public string Category { get; set; }

        /// <summary>
        /// Product image string.
        /// </summary>
        [Required]
        public string Image { get; set; }

        public Product(string name, string description, decimal price, string category, string image)
        {
            this.Id = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            Image = image;
        }
    }
}
