using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CStoreAPI.Data.Models
{
    [Keyless]
    public class Admin
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Invalid password format")]
        public string Password { get; set; } = null!;
    }
}
