namespace EbayView.Controllers.Shippers
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Shippers;
    using global::Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class ShippersController : Controller
    {
        private readonly IShipperRepository _ShipperRepository;
        private readonly IMapper _mapper;
        public ShippersController(IShipperRepository ShipperRepository, IMapper mapper)
        {
            _ShipperRepository = ShipperRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Shippers = await _ShipperRepository.GetShipperAsync(); 
            var result = _mapper.Map<List<GetShippersOutputModel>>(Shippers); 
            return View(result);
        }
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var Shipper = await _ShipperRepository.GetShipperDetailsAsync(id);
            var result = _mapper.Map<GetShipperDetailsOutputModel>(Shipper);
            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateShipperInputModel model)
        {
            try
            {
                var Shipper = _mapper.Map<Shipper>(model);
                await _ShipperRepository.AddShipperAsync(Shipper);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Shipper = await _ShipperRepository.GetShipperDetailsAsync(id);
            var result = _mapper.Map<CreateShipperInputModel>(Shipper);
            return View(result); 
        }  
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Edit(CreateShipperInputModel model)
        {
            try
            {
                var Shipper = _mapper.Map<Shipper>(model);
                await _ShipperRepository.UpdateShipperAsync(Shipper);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //var Shipper = await _ShipperRepository.GetShipperDetailsAsync(id);
            //var result = _mapper.Map<GetShipperDetailsOutputModel>(Shipper);
            //return View(result);

            // add by aly 
            var stock = await _ShipperRepository.GetShipperDetailsAsync(id);
            await _ShipperRepository.DeleteShipperAsync(stock);
            return RedirectToAction(nameof(Index));
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostDelete(int id)
        {
            try
            {
                var Shipper = await _ShipperRepository.GetShipperDetailsAsync(id);
                await _ShipperRepository.DeleteShipperAsync(Shipper);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
