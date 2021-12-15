namespace EbayView.Controllers.Account
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Account;
    using global::Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
   
    public class AccountsController : Controller
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        public AccountsController(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }
        
        [HttpGet, ActionName("Login")]
        public ActionResult Login()
        { 
            return View();
        }
        
        //[ValidateAntiForgeryToken]
        [HttpPost,ActionName("Loginuser")] 
        public async Task<IActionResult> Loginuser(PostLoginModel model)
        {  // this all are error fix it 
            ///findadminlogin
            var admin = await _adminRepository.findadminlogin(model.UserName, model.Password);
            if(admin !=null)
            {
               
                //ViewData["admin"] = admin;
                //return RedirectToAction("Index", "Home");
                TempData["admin"] = admin;
                return RedirectToAction("Index", "Home"); 
            }
            //HttpContext.Session.SetString("login", "login");
            else
            {
                ViewBag.errormsg = "not found this username and password tey to register with new acount";
                return RedirectToAction("Login", "Accounts");
                //return Redirect("/Accounts/Login");
            }
        } 

        //[ValidateAntiForgeryToken]
        [HttpPost, ActionName("register")]
        public async Task<IActionResult> register(PostLoginModel model)
        {
            try
            { 
                var admin = _mapper.Map<Admin>(model);
                await _adminRepository.AddAdminAsync(admin);
                ViewData["admin"] = admin;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Accounts", "Login");
            }
        }

    }
}
