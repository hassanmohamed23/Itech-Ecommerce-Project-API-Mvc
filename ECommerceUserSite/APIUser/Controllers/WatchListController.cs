using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace APIUser.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        IRepository<WatchList> WatchListRepo;
        IUnitOfWork IunitOfWork;
        ResultViewModel Result;

        public WatchListController(IUnitOfWork _IunitOfWork)
        {
            IunitOfWork = _IunitOfWork;
            WatchListRepo = IunitOfWork.GetWatchListRepo();
            Result = new ResultViewModel();
        }


        //return  All WatchList
        [HttpGet]
        [Route("WatchList/{userId}")]
        public async Task<ResultViewModel> GetWatchList(int userId)
        {
            Result.Data = await WatchListRepo.FindByCondition(i => i.UserId == userId);
            Result.IsSucess = true;
            return Result;
        }

        [HttpPost]
        [Route("WatchList/add")]
        public async Task<ResultViewModel> AddWatchList(WatchList watchlist)
        {
            Result.Data = await WatchListRepo.Add(watchlist);
            await IunitOfWork.Save();
            Result.Message = "Add Successfully";
            Result.IsSucess = true;
            return Result;
        }
        [HttpDelete]
        [Route("WatchList/delete")]
        public async Task<ResultViewModel> DeleteWatchList(WatchList watchlist)
        {
            Result.Data = await WatchListRepo.Remove(watchlist);
            await IunitOfWork.Save();
            Result.Message = "Deleted Successfully";
            Result.IsSucess = true;
            return Result;
        }



    }
}
