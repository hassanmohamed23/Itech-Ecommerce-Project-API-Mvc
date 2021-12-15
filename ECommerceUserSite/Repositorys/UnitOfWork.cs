using DBContext;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
   public class UnitOfWork :IUnitOfWork
    {
        myDbContext Context;
        IRepository<Product> PrdRepo;
        IRepository<Category> CatRepo;
        IRepository<SubCategory> SubCatRepo;
        IRepository<Brands> BrandRepo;
        IRepository<Comment> CommentRepo;
        IRepository<Rates>RateRepo;
        IRepository<WatchList> WatchListRepo;
        IRepository<Order> OrderRepo;
        IRepository<ProductImg> PrdImgRepo;
        IRepository<Offers> OfferRepo;
        IRepository<User> UserRepo;
        public UnitOfWork(myDbContext context, IRepository<Product> _PrdRepo,IRepository<Category> _CatRepo,
            IRepository<SubCategory> _SubCatRepo,IRepository<Brands> _BrandRepo, IRepository<Comment> _CommentRepo,
            IRepository<Rates> _RateRepo, IRepository<WatchList> _WatchListRepo,IRepository<Order> _OrderRepo,
             IRepository<ProductImg> _PrdImgRepo, IRepository<Offers> _OfferRepo, IRepository<User> _UserRepo)
        {
            Context = context;
            PrdRepo = _PrdRepo;
            CatRepo = _CatRepo;
            SubCatRepo = _SubCatRepo;
            BrandRepo = _BrandRepo;
            CommentRepo = _CommentRepo;
            RateRepo = _RateRepo;
            WatchListRepo = _WatchListRepo;
            OrderRepo = _OrderRepo;
            PrdImgRepo = _PrdImgRepo;
            OfferRepo = _OfferRepo;
            UserRepo = _UserRepo;

        }
        public IRepository<Product> GetPrdRepo()
        {
            return PrdRepo;
        }
        public IRepository<ProductImg> GetPrdImgRepo()
        {
            return PrdImgRepo;
        }
        public IRepository<Category> GetCatRepo()
        {
            return CatRepo;
        }

        public IRepository<SubCategory> GetSubCatRepo()
        {
            return SubCatRepo;
        }
        public IRepository<Brands> GetBrandRepo()
        {
            return BrandRepo;
        }

        public IRepository<Comment> GetCommentRepo()
        {
            return CommentRepo;
        }
        public IRepository<Rates> GetRateRepo()
        {
            return RateRepo;
        }
        public IRepository<WatchList> GetWatchListRepo()
        {
            return WatchListRepo;
        }
        public IRepository<Order> GetOrderRepo()
        {
            return OrderRepo;
        }

        public IRepository<Offers> GetOfferRepo()
        {
            return OfferRepo;
        }

        public IRepository<User> GetUserRepo()
        {
            return UserRepo;
        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }

    }
}
