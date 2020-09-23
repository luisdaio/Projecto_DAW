using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class Watch : BaseEntity
    {
        /// <summary>
        /// Watch Name.
        /// </summary>
        [StringLength(50)]
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Watch description.
        /// </summary>
        [DisplayName("Drescription")]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Watch price.
        /// </summary>
        [Required]
        [DisplayName("Price")]
        [Range(0, 1000000)]
        public decimal Price { get; set; }

        /// <summary>
        /// Watch Brand allowing grouping and filtering.
        /// </summary>
        [Required]
        public string Brand { get; set; }

        /// <summary>
        /// Watch image string.
        /// </summary>
        public string Image { get; set; }
    }
}
