using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KailahsCloset.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Display Name")]
        [Range(1,100, ErrorMessage = "Number needs to be between 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}
