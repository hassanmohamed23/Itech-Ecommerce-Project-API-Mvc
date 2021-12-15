namespace EbayView.Models.ViewModel.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class PostLoginModel
    {
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = "";
        public string FistName { get; set; } = "";
        public string LastName { get; set; } = "";
        //public bool check { get; set; } = false;

        
        //[EmailAddress(ErrorMessage = "Invalid email address")]
       // public string Email { get; set; }
        
        //[MinLength(6, ErrorMessage = "Min Length 6 characters")]
        //public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
