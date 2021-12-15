using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Repositorys;

namespace APIUser.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration _configuration;
        private ResultViewModel Result;
        IRepository<User> UserRepo;
        IUnitOfWork IunitOfWork;
        IUserRepository _UserRepo;




        public AuthenticateController(UserManager<User> userManager,
        IConfiguration configuration, IUnitOfWork _IunitOfWork, IUserRepository _UserRepo)
        {
            this.userManager = userManager;
            _configuration = configuration;
            Result = new ResultViewModel();
            IunitOfWork =  _IunitOfWork;
            UserRepo = IunitOfWork.GetUserRepo();
           this._UserRepo = _UserRepo;

        }
        [HttpPost]
        [Route("login")]
        public async Task<AuthModel> Login([FromBody] LoginModel model)
        {
            return await _UserRepo.Login(model);
        }

        [HttpPost]
        [Route("Signup")]
        public async Task<AuthModel> Signup([FromBody] RegisterModel model)
        {
            return await _UserRepo.SignUp(model);
        }

        [HttpPost]
        [Route("SignupAdmin")]
        public async Task<AuthModel> SignupAdmin([FromBody] RegisterModel model)
        {
            return await _UserRepo.SignUpAdmin(model);
        }

        /* [HttpPost]
         [Route("login")]
         public async Task<IActionResult> Login([FromBody] LoginModel model)
         {
             var user = await userManager.FindByNameAsync(model.Username);
             if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
             {
                 var userRoles = await userManager.GetRolesAsync(user);

                 var authClaims = new List<Claim>
                 {
                     new Claim(ClaimTypes.Name, user.UserName),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 };

                 foreach (var userRole in userRoles)
                 {
                     authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                 }

                 var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                 var token = new JwtSecurityToken(
                     issuer: _configuration["JWT:ValidIssuer"],
                     audience: _configuration["JWT:ValidAudience"],
                     expires: DateTime.Now.AddHours(3),
                     claims: authClaims,
                     signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                     );

                 return Ok(new
                 {
                     token = new JwtSecurityTokenHandler().WriteToken(token),
                     expiration = token.ValidTo,
                     userName= user.UserName,
                     userId= user.Id,
                 });
             }
             return Unauthorized();
         }

         [HttpPost]
         [Route("register")]
         public async Task<IActionResult> Register([FromBody] RegisterModel model)
         {
             var userExists = await userManager.FindByNameAsync(model.Username);
             if (userExists != null)
                 return StatusCode(StatusCodes.Status500InternalServerError, new ResultViewModel { IsSucess = false, Message = "User already exists!" });

             User user = new User()
             {
                 FistName=model.FirstName,
                 LastName=model.LastName,
                 Email = model.Email,
                 SecurityStamp = Guid.NewGuid().ToString(),
                 UserName = model.Username
             };
             var result = await userManager.CreateAsync(user, model.Password);
             if (!result.Succeeded)
                 return StatusCode(StatusCodes.Status500InternalServerError, new ResultViewModel { IsSucess = false, Message = "User creation failed! Please check user details and try again." });

             return Ok(new ResultViewModel { IsSucess = true, Message = "User created successfully!" });
         }*/

         // Get userprofile by UserID 
        [HttpGet]
        [Route("Profile/{UserId}")]
        public async Task<IActionResult> UserProfile(int UserId)
         {

             var user = await UserRepo.GetByIDAsync(UserId);
             return Ok(new {
                 Id = user.Id,
                 firstname= user.FistName,
                 lastname=user.LastName,
                 username=user.UserName,
                 email=user.Email,
             });
         }

         [HttpPost]
         [Route("Profile/ChangePassword")]
         public async Task<IActionResult> ChangePassword(ChangePasswordModel _user)
         {

             var user =await userManager.FindByIdAsync(_user.Id.ToString());
             if (user == null)
             {
                 return NotFound();
             }

             user.PasswordHash = userManager.PasswordHasher.HashPassword(_user.Tomodel(), _user.Password);
             var result = await userManager.UpdateAsync(user);

             if (!result.Succeeded)
             {
                 return Ok("Failed to Change password");
             }

             return Ok("Password Updated Sucessfully");
         }

         [HttpPost]
         [Route("Profile/Edit")]
         public async Task<IActionResult> UserEditProfile(EditUserProfileModel model)
         {

             var user = await userManager.FindByIdAsync(model.Id.ToString());

             if (user == null)
             {
                 return Ok("NotFound");
             }
             else
             {
                 user.FistName = model.FirstName;
                 user.LastName = model.LastName;
                 user.City = model.City;
                 user.Country = model.Country;
                 user.ZIP = model.ZIP;
                 user.FullAddress = model.FullAddress;
                 var result = await userManager.UpdateAsync(user);
                 return Ok("Profile Updated Sucessfully");
             }
         }

        
    }
}
