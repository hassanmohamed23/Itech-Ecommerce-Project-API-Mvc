namespace EbayView.Controllers.Products
{
    using AutoMapper;
    using EbayAdminModels.Category;
    using EbayAdminModels.SubCategory;
    using EbayView.Models;
    using EbayView.Models.ViewModel.Brands;
    using EbayView.Models.ViewModel.Category;
    using EbayView.Models.ViewModel.Products;
    using EbayView.Models.ViewModel.Stocks;
    using EbayView.Models.ViewModel.SubCategory;
    using global::Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subcategoryRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IBrandRepository _brandRepository;
        public ProductsController(IProductRepository productRepository, IMapper mapper
            ,ICategoryRepository categoryRepository, ISubCategoryRepository subcategoryRepository,
            IBrandRepository brandRepository,IStockRepository stockRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _stockRepository = stockRepository;
            _subcategoryRepository = subcategoryRepository;

        }

        [HttpGet] // finshed
        public async Task<IActionResult> Index()
        {
            //object o = TempData.Peek("admin");
            //ViewBag.admin = (o == null ? null : JsonSerializer.Deserialize<Admin>((string)o));
            //var value = HttpContext.Session.GetString("login"); 
            //if (!string.IsNullOrWhiteSpace(value))
            //{
            var products = await _productRepository.GetProductsAsync();
                var result = _mapper.Map<List<GetProductsOutputModel>>(products);
           // TempData.Keep("admin");
            return View(result);
            //}
            //return RedirectToAction("Login","User");

        }
        [HttpGet]// error
        public async Task<ActionResult> Create()
        {
            // made by aly
            //var Admins = await _categoryRepository.GetCategoriesAsync();
            //var AllAdminsResult = _mapper.Map<List<GetCategoriesOutputModel>>(Admins);
            //ViewBag.AvailableAdmins = AllAdminsResult;

            var categories = await _categoryRepository.GetCategoriesAsync();
            var AllcategoriesResult = _mapper.Map<List<GetCategoriesOutputModel>>(categories);
            ViewBag.AvailableCategories = AllcategoriesResult;

            var subcategories = await _subcategoryRepository.GetSubCategoriesAsync();
            var AllsubcategoriesResult = _mapper.Map<List<GetSubCategoriesOutputModel>>(subcategories);
            ViewBag.AvailableSubCategories = AllsubcategoriesResult;

            var brands = await _brandRepository.GetBrandsAsync();
            var AllbrandsResult = _mapper.Map<List<GetBrandsOutputModel>>(brands);
            ViewBag.AvailableBrands = AllbrandsResult;

            var stocks = await _stockRepository.GetStockAsync();
            var AllstocksResult = _mapper.Map<List<GetStocksOutputModel>>(stocks);
            ViewBag.AvailableStock = AllstocksResult;

            //CreateProductInputModel metaData = new CreateProductInputModel(); 
            //metaData.AvailableCategories = AllcategoriesResult;
            //metaData.AvailableSubCategories = AllsubcategoriesResult;
            //metaData.AvailableBrands = AllbrandsResult;
            //metaData.AvailableStock = AllstocksResult;
            //return View(metaData);
            return View();
        } 
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create(CreateProductInputModel model)
        {
            
               var product = _mapper.Map<Product>(model); 
            await _productRepository.AddProductAsync(product);
            ///impsrepostory.add(model.imgspathes)
            //return View(product);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return  BadRequest(HttpStatusCode.BadRequest);
            }
            var product = await _productRepository.GetProductDetailsAsync(id.Value);

            if (product == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            var result = _mapper.Map<GetProductDetailsOutputModel>(product);

            return View(result);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return  BadRequest(HttpStatusCode.BadRequest);
            }
            var product = await _productRepository.GetProductDetailsAsync(id.Value);

            if (product == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            var result = _mapper.Map<GetProductDetailsOutputModel>(product);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CreateProductInputModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                await _productRepository.UpdateProductAsync(product);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            } 
            var product = await _productRepository.GetProductDetailsAsync(id.Value); 
            if (product == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            var result = _mapper.Map<GetProductDetailsOutputModel>(product);

            //return View("producat is deleted");
            // add by aly
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var product = await _productRepository.GetProductDetailsAsync(id);

             await _productRepository.DeleteProductAsync(product);
            return RedirectToAction("Index");
        }
    }
}
