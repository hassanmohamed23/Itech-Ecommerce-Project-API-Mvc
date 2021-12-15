using AutoMapper;
using EbayView.Models;
using EbayView.Models.ViewModel;
using EbayView.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;

namespace EbayView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IHomeRepository _homeRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger
            , IProductRepository productRepository, IHomeRepository homeRepository,
            IMapper mapper)
        { 
                _productRepository = productRepository;
            _homeRepository = homeRepository;
            _mapper = mapper;
             
        }

        [HttpGet] 
        public async Task<IActionResult> Index()
        {
            //if (TempData["admin"] != null)
            if (HttpContext.Session.GetObjectFromJson("admin") !=null)
                {
                //object o = TempData.Peek("admin");
                //ViewBag.admin= (o == null ? null : JsonSerializer.Deserialize<Admin>((string)o));
                //HttpContext.Session.GetObjectFromJson
                var dataCount = await _homeRepository.GetDataCountAsync();
                var result = _mapper.Map<GetStatisticsOutputModel>(dataCount);
                //TempData.Keep("admin");
                return View(result);
            }
            else
            {
                //return RedirectToAction("Login","Accounts");
                return RedirectToAction("Signin", "Account");
                
            }
        } 
        //public IActionResult Privacy()
        //{
        //    return View();
        //} 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
