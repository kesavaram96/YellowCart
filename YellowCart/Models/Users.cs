using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YellowCart.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
     
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }
        public string UserType { get; set; } = "user";

    }
}
