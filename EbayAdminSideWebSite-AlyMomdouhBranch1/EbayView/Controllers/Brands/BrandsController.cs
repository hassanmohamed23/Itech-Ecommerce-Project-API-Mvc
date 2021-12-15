namespace EbayView.Controllers.Brands
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Brands;
    using global::Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //finshed  slove all problem
    public class BrandsController : Controller   
    {
        private readonly IBrandRepository _BrandRepository;
        private readonly IMapper _mapper;
        public BrandsController(IBrandRepository BrandRepository, IMapper mapper)
        {
            _BrandRepository = BrandRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Brands = await _BrandRepository.GetBrandsAsync(); 
            var result = _mapper.Map<List<GetBrandsOutputModel>>(Brands); 
            return View(result);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {// beause ahmed not get any thing 
            var Brand = await _BrandRepository.GetBrandDetailsAsync(id);
            var result = _mapper.Map<GetBrandDetailsOutputModel>(Brand);
            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBrandInputModel model)
        {
            var Brand = _mapper.Map<Brands>(model);
            await _BrandRepository.AddBrandAsync(Brand);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Brands brand = await _BrandRepository.GetBrandDetailsAsync(id);
            var result = _mapper.Map<GetBrandDetailsOutputModel>(brand);
            //return View(result);
            // add by aly 
            ViewBag.oldbrand = result;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateBrandInputModel model)
        {
            var Brand = _mapper.Map<Brands>(model);
            await _BrandRepository.UpdateBrandAsync(Brand);
            return RedirectToAction(nameof(Index));
        } 
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //Brands brand = await _BrandRepository.GetBrandDetailsAsync(id);
            //var result = _mapper.Map<GetBrandDetailsOutputModel>(brand); 
            //return View(result);
            var brand = await _BrandRepository.GetBrandDetailsAsync(id);
            await _BrandRepository.DeleteBrandAsync(brand);
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]// ahmed
        //[HttpPost, ActionName("Delete")]// aly
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> PostDelete(int id)
        //{
        //    try
        //    {
        //        var brand = await _BrandRepository.GetBrandDetailsAsync(id);
        //        await _BrandRepository.DeleteBrandAsync(brand);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
