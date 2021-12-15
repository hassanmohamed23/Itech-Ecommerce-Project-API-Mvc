namespace EbayView.Controllers.Admins
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Account;
    using EbayView.Models.ViewModel.admns;
    using global::Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class AdminsController : Controller
    {
        private readonly IAdminRepository _AdminRepository;
        private readonly IMapper _mapper;
        public AdminsController(IAdminRepository AdminRepository, IMapper mapper)
        {
            _AdminRepository = AdminRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Admins = await _AdminRepository.GetAdminAsync(); 
            var result = _mapper.Map<List<GetAdminsOutputModel>>(Admins); 
            return View(result);
        }
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var Admin = await _AdminRepository.GetAdminDetailsAsync(id);
            var result = _mapper.Map<GetAdminDetailsOutputModel>(Admin);    
            return View(result);
        }  
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAdminInputModel model)
        {
            try
            {
                var Admin = _mapper.Map<Admin>(model);
                await _AdminRepository.AddAdminAsync(Admin);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Admin = await _AdminRepository.GetAdminDetailsAsync(id);
            var result = _mapper.Map<GetAdminDetailsOutputModel>(Admin);
            ViewBag.selectedadmin = result;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Edit(CreateAdminInputModel model)
        {
            try
            {
                var Admin = _mapper.Map<Admin>(model);
                await _AdminRepository.UpdateAdminAsync(Admin);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit),new {id= model.AdminId });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //var Admin = await _AdminRepository.GetAdminDetailsAsync(id);
            //var result = _mapper.Map<GetAdminDetailsOutputModel>(Admin);
            //return View(result);
            var Admin = await _AdminRepository.GetAdminDetailsAsync(id);
            await _AdminRepository.DeleteAdminAsync(Admin);
            return RedirectToAction(nameof(Index));
        }

        #region //some comment
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> PostDelete(int id)
        //{
        //    try
        //    {
        //        var Admin = await _AdminRepository.GetAdminDetailsAsync(id);
        //        await _AdminRepository.DeleteAdminAsync(Admin);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //[HttpGet,ActionName("Login")]
        //public ActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public  IActionResult  Login(PostLoginModel model)
        //{
        //    try
        //    {
        //        // write your code here
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return RedirectToAction(nameof(Login));
        //    }
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult register(PostLoginModel model)
        //{
        //    try
        //    {
        //        // write your code here
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return RedirectToAction(nameof(Login));
        //    }
        //}
        #endregion 
    }
}
