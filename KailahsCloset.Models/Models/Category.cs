using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KailahsCloset.Models.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Display Name")]
        [Range(1, 100, ErrorMessage = "Number needs to be between 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}
