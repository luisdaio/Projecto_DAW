using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class Brand : BaseEntity
    {

        [StringLength(20)]
        [DisplayName("Brand")]
        [Required]
        public string Name { get; set; }
    }
}
