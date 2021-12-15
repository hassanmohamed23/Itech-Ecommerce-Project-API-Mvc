using AutoMapper;
using EbayView.Models.ViewModel.Account;
using EbayView.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayView.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        public AccountController(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(SignupVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Admin admin = new Admin()
                    {
                        Email = model.Email, 
                        Password=model.Password,
                        FistName=model.FistName,
                        LastName=model.LastName,
                        UserName=model.UserName,
                        Salary=3000,
                        //IsAgree = model.IsAgree
                    };
                    // We pass the password separate to make it hash
                    //var userResult = await userManager.CreateAsync(user, model.Password);
                    // We add the user to the User role as default role
                    //var roleResult = await userManager.AddToRoleAsync(user, "User");
                    await _adminRepository.AddAdminAsync(admin);
                    
                    if(admin.AdminId!=0)
                    {
                        //return RedirectToAction("Signin");
                        //TempData["admin"] = JsonConvert.SerializeObject(admin);
                        HttpContext.Session.SetObjectAsJson("admin", admin);
                        return RedirectToAction("Index", "Home");
                    }
                     
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }


        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signin(SigninVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                    var admin = await _adminRepository.findadminlogin(model.Email, model.Password);
                    if (admin != null)
                    {

                        //ViewData["admin"] = admin;
                        //return RedirectToAction("Index", "Home");
                        //TempData["admin"] = JsonConvert.SerializeObject(admin);
                        HttpContext.Session.SetObjectAsJson("admin", admin);
                        return RedirectToAction("Index", "Home");
                    } 
                    else
                    {
                        ModelState.AddModelError("", "Invalid UserName Or Password"); 
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }  
        [HttpGet]
        public  IActionResult Logout()
        {
                HttpContext.Session.Remove("admin");
            return RedirectToAction("Signin", "Account");
        }
    }
}
