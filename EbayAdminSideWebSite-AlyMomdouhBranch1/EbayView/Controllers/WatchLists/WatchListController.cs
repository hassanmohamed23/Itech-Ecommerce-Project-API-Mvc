namespace EbayView.Controllers.WatchLists
{
    using AutoMapper;
    using EbayView.Models.ViewModel.WatchLists;
    using global::Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class WatchListController : Controller
    {
        private readonly IWatchListRepository _WatchListRepository;
        private readonly IMapper _mapper;
        public WatchListController(IWatchListRepository WatchListRepository, IMapper mapper)
        {
            _WatchListRepository = WatchListRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var WatchLists = await _WatchListRepository.GetWatchListAsync();

            var result = _mapper.Map<List<GetWatchListOutputModel>>(WatchLists);

            return View(result);
        }
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var WatchList = await _WatchListRepository.GetWatchListDetailsAsync(id);
            var result = _mapper.Map<GetWatchListDetailsOutputModel>(WatchList);
            return View(result);
        }
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CreateWatchistInputModel model)
        //{
        //    try
        //    {
        //        var Watchlist = _mapper.Map<WatchList>(model);
        //        await _WatchListRepository.AddWatchListAsync(Watchlist);
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
        //    var WatchList = await _WatchListRepository.GetWatchListDetailsAsync(id);
        //    var result = _mapper.Map<GetWatchListDetailsOutputModel>(WatchList);
        //    return View(result);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> PostDelete(int id)
        //{
        //    try
        //    {
        //        var WatchList = await _WatchListRepository.GetWatchListDetailsAsync(id);
        //        await _WatchListRepository.DeleteWatchListAsync(WatchList);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
