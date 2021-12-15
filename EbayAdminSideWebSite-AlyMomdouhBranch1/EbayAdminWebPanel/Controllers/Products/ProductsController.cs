using EbayAdminModels.Products;
using EbayAdminWebPanel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbayAdminWebPanel.Controllers.Products
{

  
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(PostProductViewModel model)
        {
            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price
            };
          await  _productRepository.AddProductAsync(product);
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> GetProductAsync( )
        {

         List<Product> products =   await _productRepository.GetProductsAsync();
            return View(products);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
