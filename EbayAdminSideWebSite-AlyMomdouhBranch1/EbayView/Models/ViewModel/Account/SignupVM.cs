using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayView.Models.ViewModel.Account
{
    public class SignupVM
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5,ErrorMessage = "Min Length 5 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Min Length 5 characters")]
        [Compare("Password", ErrorMessage = "Password not match")]
        public string ConfirmPassword { get; set; } 

        public string UserName { get; set; } 
        public string FistName { get; set; } = "";
        public string LastName { get; set; } = "";

        public bool IsAgree { get; set; }
    }
}
