using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace YellowCart.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
