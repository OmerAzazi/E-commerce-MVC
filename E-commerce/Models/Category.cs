using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Category
    {
        //prop
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}
