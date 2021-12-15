using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AddRoleModel
    {
        [Required]
        public int UserID { set; get; }
        [Required]
        public string Role { set; get; }
    }
}
