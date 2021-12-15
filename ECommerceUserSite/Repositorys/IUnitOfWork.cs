using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public interface IUnitOfWork
    {
        IRepository<Product> GetPrdRepo();
        IRepository<ProductImg> GetPrdImgRepo();
        IRepository<Category> GetCatRepo();
        IRepository<SubCategory> GetSubCatRepo();
        IRepository<Brands> GetBrandRepo();
        IRepository<Comment> GetCommentRepo();
        IRepository<Rates> GetRateRepo();
        IRepository<WatchList> GetWatchListRepo();
        IRepository<Order> GetOrderRepo();
        IRepository<Offers> GetOfferRepo();
        IRepository<User> GetUserRepo();
        Task Save();
    }
}
