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
    //[Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        IRepository<Order> OrderRepo;
        IUnitOfWork IunitOfWork;
        ResultViewModel Result;

        public OrderController(IUnitOfWork _IunitOfWork)
        {
            IunitOfWork = _IunitOfWork;
            OrderRepo = IunitOfWork.GetOrderRepo();
            Result = new ResultViewModel();
        }

        //get Order by User ID 
        [HttpPost]
        [Route("Order/{userId}")]
        public async Task<ResultViewModel> GetOrder(int userId)
        {
            Result.Data = await OrderRepo.FindByCondition(i => i.UserId == userId);
            Result.IsSucess = true;
            return Result;
        }

        //Add Order  to database
        [HttpPost]
        [Route("Order/add")]
        public async Task<ResultViewModel> AddOrder(Order order)
        {
            Result.Data = await OrderRepo.Add(order);
            await IunitOfWork.Save();
            Result.IsSucess = true;
            Result.Message ="Added Successfully";
            return Result;
        }

        //Delete Order  to database
        [HttpDelete]
        [Route("Order/delete")]
        public async Task<ResultViewModel> DeleteOrder(Order order)
        {
            Result.Data = await OrderRepo.Remove(order);
            await IunitOfWork.Save();
            Result.Message = "Deleted Successfully";
            Result.IsSucess = true;
            return Result;
        }

    }
}
