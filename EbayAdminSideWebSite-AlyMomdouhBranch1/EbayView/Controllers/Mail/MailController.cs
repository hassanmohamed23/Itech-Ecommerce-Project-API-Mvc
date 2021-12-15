using EbayView.Models.ViewModel.Users;
using EbayView.Services;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Models;
using AutoMapper;

namespace EbayView.Controllers.Mail
{
    public class MailController : Controller
    {
        private readonly IMailServices mailServices;
        private readonly UserManager<User> userManager;
        private readonly IMapper _mapper;
        private static  GetUsserDetailsOutputModel user;
        public MailController(IMailServices _mailServices, UserManager<User> userManager, IMapper mapper)
        {
            mailServices = _mailServices;
            this.userManager = userManager;
            _mapper = mapper;
        }
        //public  IActionResult index(GetUsserDetailsOutputModel userinfo)
        public  IActionResult index(GetUsserDetailsOutputModel userinfo)
        {
            //@model EbayView.Models.ViewModel.Users.GetUsserDetailsOutputModel
            user = userinfo;
            return View(userinfo);
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailServices.SendEmailAsync(request.ToEmail, request.Subject, request.Body, request.Attachments);
                return Ok();
            }
            catch (Exception ex)
            {
                throw; 
            } 
        }
        //[HttpPost("welcome")]
        //public async Task<IActionResult> SendWelcomeEmail([FromBody] WelcomeRequest dto)
        public async Task<IActionResult> SendWelcomeEmail()
        {
            var filePath = $"{Directory.GetCurrentDirectory()}\\Views\\Mail\\WelcomeTemplate.html";
            var str = new StreamReader(filePath);

            var mailText = str.ReadToEnd();
            str.Close(); 
            mailText = mailText.Replace("[username]", user.UserName).Replace("[email]", user.Email)
                .Replace("[FistName]", user.FistName).Replace("[LastName]", user.LastName);

            await mailServices.SendEmailAsync(user.Email, "Welcome to our ecommerce website ", mailText);
            //return Ok();
            return RedirectToAction("index",user.UserId);
        }
        [HttpPost("EmailConfirmed")]
        //public async Task<IActionResult> EmailConfirmed(GetUsserDetailsOutputModel userinfo)
        public void EmailConfirmed(GetUsserDetailsOutputModel userinfo)
        {
            //user = userinfo;
            //try
            //{
            //    await mailServices.SendEmailAsync(request.ToEmail, request.Subject, request.Body, request.Attachments);
            //    return Ok();
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }

        private async Task<string> generateToken()
        {
            // add code to generate email and confirmation link and sent to uer 
            var mainuser = _mapper.Map<User>(user);
            var token = await userManager.GenerateEmailConfirmationTokenAsync(mainuser);//UserManager.GenerateEmailConfirmationTokenAsync(user);
              byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
            var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);
            var param = new Dictionary<string, string>
            {
                {"token",codeEncoded },{"email",mainuser.Email}
            };
            var callback = QueryHelpers.AddQueryString(mainuser.ActivationCode, param);

                return callback;// the ActivationCode or Activationurl 
        } 
    }
}
