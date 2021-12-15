using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class User :IdentityUser<int>
    {
       // public int UserId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
       // public string UserName { get; set; }
       // public string Email { get; set; }
       // public string Password { get; set; }
        public string Img { get; set; }
       // public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int ZIP { get; set; }
        public string FullAddress { get; set; }
        public string ActivationCode { get; set; }
    }
    public partial class User
    {
        public ICollection<Rates> rates { get; set; }
        public ICollection<Cart> carts { get; set; }
        public ICollection<Comment> comments { get; set; }
        public ICollection<Order> orders { get; set; }
        public ICollection<WatchList> watchLists { get; set; }
        
    }
}
