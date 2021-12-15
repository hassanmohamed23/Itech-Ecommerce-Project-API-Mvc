namespace EbayView.Controllers.Orders
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Orders;
    using global::Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IMapper _mapper;
        public OrdersController(IOrderRepository OrderRepository, IMapper mapper)
        {
            _OrderRepository = OrderRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Orders = await _OrderRepository.GetOrdersAsync();

            var result = _mapper.Map<List<GetOrdersOutputModel>>(Orders);

            return View(result);
        }
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var Order = await _OrderRepository.GetOrderDetailsAsync(id);
            var result = _mapper.Map<GetOrderDetailsOutputModel>(Order);
            return View(result);
        }
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

 
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create( CreateOrderInputModel model)
        //{
        //    try
        //    {
        //        var Order = _mapper.Map<Order>(model);
        //        await _OrderRepository.AddOrderAsync(Order);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var Order = await _OrderRepository.GetOrderDetailsAsync(id);
        //    var result = _mapper.Map<GetOrderDetailsOutputModel>(Order);
        //    return View(result);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> PostDelete(int id)
        //{
        //    try
        //    {
        //        var stock = await _OrderRepository.GetOrderDetailsAsync(id);
        //        await _OrderRepository.DeleteOrderAsync(stock);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
