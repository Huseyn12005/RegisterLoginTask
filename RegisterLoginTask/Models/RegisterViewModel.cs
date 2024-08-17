using System.ComponentModel.DataAnnotations;

namespace RegisterLoginTask.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Passsword is required")]
        [StringLength(100,MinimumLength =8,ErrorMessage = "Password must be at least 8 characters long")]
        public string? Password { get; set; }

        [Compare("Password",ErrorMessage ="Confirm Password doesnt much")]
        public string? ConfirmPassword { get; set; }
    }
}
