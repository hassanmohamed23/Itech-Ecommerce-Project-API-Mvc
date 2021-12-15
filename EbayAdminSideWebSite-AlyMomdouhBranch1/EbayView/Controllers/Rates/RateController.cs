namespace EbayView.Controllers.Rates
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Rates;
    using global::Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public class RateController : Controller
    {
        private readonly IRateRepository _RateRepository;
        private readonly IMapper _mapper;
        public RateController(IRateRepository RateRepository, IMapper mapper)
        {
            _RateRepository = RateRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int userId)
        {
            var Rates = await _RateRepository.GetRatesAsync(userId);

            var result = _mapper.Map<List<GetRateOutputModel>>(Rates);

            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var Comments = await _RateRepository.GetRateDetailsAsync(id);

            return View(Comments);
        }
       




    }
}
