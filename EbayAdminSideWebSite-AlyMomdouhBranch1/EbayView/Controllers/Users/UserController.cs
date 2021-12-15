namespace EbayView.Controllers.Users
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Users;
    using global::Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class UsersController : Controller
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Users = await _UserRepository.GetUserAsync(); 
            var result = _mapper.Map<List<GetUsersOutputModel>>(Users); 
            return View(result);
        }
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var User = await _UserRepository.GetUserDetailsAsync(id);
            var result = _mapper.Map<GetUsserDetailsOutputModel>(User);
            return View(result);
        } 
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //var User = await _UserRepository.GetUserDetailsAsync(id);
            //var result = _mapper.Map<GetUsserDetailsOutputModel>(User);
            //return View(result);

            // add by aly
            try
            {
                var User = await _UserRepository.GetUserDetailsAsync(id);
                await _UserRepository.DeleteUserAsync(User);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> sendemail(int id)
        {
            var User = await _UserRepository.GetUserDetailsAsync(id);
            var userinfo = _mapper.Map<GetUsserDetailsOutputModel>(User);
            return RedirectToAction("index", "Mail", userinfo);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> PostDelete(int id)
        //{
        //    try
        //    {
        //        var User = await _UserRepository.GetUserDetailsAsync(id);
        //        await _UserRepository.DeleteUserAsync(User);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
