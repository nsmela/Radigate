using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public class UserRegisteration {
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100, MinimumLength = 6)]
        //[RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])", ErrorMessage = "Invalid password! Requires at least: one capital letter, one lower-case letter, and one number")]
        //couldn't get it to work. No passwords would pass this expression. Tested fine online.
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "The passwords do not match")] public string ConfirmPassword { get; set; } = string.Empty;

    }
}
