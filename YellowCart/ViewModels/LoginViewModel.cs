using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace YellowCart.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
