using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class EditUserProfileModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }
        public string Img { get; set; }

        [Required(ErrorMessage = "Country Required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "City Required")]
        public string City { get; set; }
        public int ZIP { get; set; }
        [Required(ErrorMessage = "Address Required")]
        public string FullAddress { get; set; }

    }

    public static class EditUserProfileModelExtension
    {
        public static User Tomodel(this  EditUserProfileModel model)
        {
            return new User()
            {
                Id=model.Id,
                FistName = model.FirstName,
                LastName = model.LastName,
                Img = model.Img,
                Country = model.Country,
                City = model.City,
                ZIP = model.ZIP,
                FullAddress = model.FullAddress
            

            };
        }
    }
}
