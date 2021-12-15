using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUser.Controllers
{
    [Authorize(Roles ="User")]
   // [Route("Product")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ProductController : ControllerBase
    {
        IRepository<Product> PrdRepo;
        IRepository<Category> CatRepo;
        IRepository<SubCategory> SubCatRepo;
        IRepository<Brands> BrandsRepo;
        IRepository<ProductImg> PrdImgRepo;
        IRepository<Offers> OfferRepo;
        IUnitOfWork IunitOfWork;
        ResultViewModel Result;
        public ProductController(IUnitOfWork _IunitOfWork )
        {
            IunitOfWork = _IunitOfWork;
            PrdRepo = IunitOfWork.GetPrdRepo();
            CatRepo = IunitOfWork.GetCatRepo();
            SubCatRepo = IunitOfWork.GetSubCatRepo();
            BrandsRepo = IunitOfWork.GetBrandRepo();
            PrdImgRepo = IunitOfWork.GetPrdImgRepo();
            OfferRepo = IunitOfWork.GetOfferRepo();
            Result = new ResultViewModel();
        }
        // return All products
        [Route("Product")]
        [HttpGet]
        public async Task<ResultViewModel> GetAllProduct()
        {
            Result.Data = await PrdRepo.GetAsync();
            Result.IsSucess = true;
            return Result;
        }
        //return  All productimg 
        [HttpGet]
        [Route("Productimg/{prdID}")]
        public async Task<ResultViewModel> GetAllPrdImg(int prdID)
        {
            Result.Data = await PrdImgRepo.FindByCondition(i => i.ProductId == prdID);
            Result.IsSucess = true;
            return Result;
        }

        //Return product By Product ID
        [HttpGet]
         [Route("Product/{PrdId}")]
         public async Task<ResultViewModel> GetPrdById(int PrdId)
         {
            Result.Data = await PrdRepo.GetByIDAsync(PrdId);
             Result.IsSucess = true;
             return Result;
         }
         //Return Product By Category ID
         [HttpGet]
         [Route("ProductByCatID/{CatID}")]
         public async Task<ResultViewModel> GetPrdByCatID(int CatID)
         { 
            Result.Data = await PrdRepo.FindByCondition(i => i.CatId == CatID);
             Result.IsSucess = true;
             return Result;
         }

         //return  All Product By SubCat 
         [HttpGet]
         [Route("ProductBySubCat/{SubCatID}")]
         public async Task<ResultViewModel> GetPrdBySubCatID(int SubCatID)
         {

             Result.Data= await PrdRepo.FindByCondition(i => i.SubCatId == SubCatID);
             Result.IsSucess = true;
             return Result;
         }
        //return  All Product By Brands 
        [HttpGet]
        [Route("ProductByBrandId/{BrandID}")]
        public async Task<ResultViewModel> GetPrdByBrandID(int BrandID)
        {

            Result.Data = await PrdRepo.FindByCondition(i => i.BrandId == BrandID);
            Result.IsSucess = true;
            return Result;
        }



        //return  All Category
         [HttpGet]
         [Route("Category")]
         public async Task<ResultViewModel> GetAllCategory()
         {
             Result.Data = await CatRepo.GetAsync();
             Result.IsSucess = true;
             return Result;
         }

        //return SubCategory By Category ID
        [HttpGet]
        [Route("SubCategoryByCatId/{CatId}")]
        public async Task<ResultViewModel> GetAllSubCategory(int CatId)
        {
            Result.Data = await SubCatRepo.FindByCondition(i=>i.CatId== CatId);
            Result.IsSucess = true;
            return Result;
        }
        //return  All SubCategory 
        [HttpGet]
         [Route("SubCategory")]
         public async Task<ResultViewModel> GetAllSubCategory()
         {
             Result.Data = await SubCatRepo.GetAsync();
             Result.IsSucess = true;
             return Result;
         }

         //return  All Brands 
         [HttpGet]
         [Route("Brands")]
         public async Task<ResultViewModel> GetAllBrands()
         {
             Result.Data = await BrandsRepo.GetAsync();
             Result.IsSucess = true;
             return Result;
         }

        //return  All Offers 
        [HttpGet]
        [Route("Offers")]
        public async Task<ResultViewModel> GetAllOffers()
        {
            Result.Data = await OfferRepo.GetAsync();
            Result.IsSucess = true;
            return Result;
        }

        //return  Offers By Prd ID
        [HttpGet]
        [Route("Offers/{PrdID}")]
        public async Task<ResultViewModel> GetOffersByProductID(int PrdID)
        {
            Result.Data = await OfferRepo.FindByCondition(i => i.ProductId == PrdID);
            if (Result.Data!=null)
            {
                Result.IsSucess = true;
                return Result;
            }
            Result.IsSucess = false;
            return Result;


        }
        //Search for Product 
        [HttpGet]
        [Route("Search/{search}")]
        public async Task<ResultViewModel> Search( string search)
        {
          if(!string.IsNullOrEmpty(search))
            {
                var Search = await PrdRepo.FindByCondition(i => i.Name.Contains(search) 
                || i.Description.Contains(search));
                Result.Data = Search;
                if (Search.Any())
                {
                    Result.IsSucess = true;
                    return Result;
                }
            }
            Result.IsSucess = false;
            Result.Message = "Product Not Found";
            return Result;
        }












    }
}
