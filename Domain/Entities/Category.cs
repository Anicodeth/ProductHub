using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{

    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        // Navigation property for products associated with this category (one-to-many)
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
