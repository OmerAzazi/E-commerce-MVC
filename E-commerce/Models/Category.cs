using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Category
    {
        //prop
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

    }
}
