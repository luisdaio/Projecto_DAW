using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class ProductCategory : BaseEntity
    {

        [StringLength(20)]
        [DisplayName("Category")]
        [Required]
        public string Name { get; set; }
    }
}
