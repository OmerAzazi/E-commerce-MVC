﻿using System.ComponentModel;
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
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100")]
        public int DisplayOrder { get; set; }

    }
}
