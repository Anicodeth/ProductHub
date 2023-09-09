using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{

    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Navigation property for user's listings
        public ICollection<Product> Products { get; set; }
    }

}
