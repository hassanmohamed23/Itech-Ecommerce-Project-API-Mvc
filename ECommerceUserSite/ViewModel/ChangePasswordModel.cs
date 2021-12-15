using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Id is Required")]
        public int Id { get; set; }
        [Required (ErrorMessage ="Password is Required")]
        public string Password { get; set; }


    }
    public static class ChangePasswordModelExtension
    {
        public static User Tomodel(this ChangePasswordModel model)
        {
            return new User()
            {
                Id = model.Id

            };
        }
    }
}
