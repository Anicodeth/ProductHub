using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{

    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Pricing { get; set; }

        [Required]
        public int Availability { get; set; }

        // Navigation property for product owner (User)
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation property for categories (many-to-many)
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }

}
