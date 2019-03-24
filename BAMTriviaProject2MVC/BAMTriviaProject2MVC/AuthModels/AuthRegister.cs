using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BAMTriviaProject2MVC.AuthModels
{
    public class AuthRegister
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [RegularExpression(@"(.*[a-z].*)(.*[0-9].*)",
            ErrorMessage = "The password must have a lowercase letter and a digit.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
