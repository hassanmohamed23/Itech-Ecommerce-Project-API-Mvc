using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repositorys
{
   public interface IUserRepository
    {
        Task<AuthModel> SignUp(RegisterModel signUpModel);
        Task<AuthModel> SignUpAdmin(RegisterModel signUpModel);
        Task<AuthModel> Login(LoginModel model);
        Task<string> AddRole(AddRoleModel Model);


    }
}
