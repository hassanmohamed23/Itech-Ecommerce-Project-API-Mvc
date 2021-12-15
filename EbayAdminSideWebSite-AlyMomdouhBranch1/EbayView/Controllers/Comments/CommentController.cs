namespace EbayView.Controllers.Comments
{
    using AutoMapper;
    using EbayView.Models.ViewModel.Comments;
    using global::Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    // finshed comment and need smallimg 
    public class CommentController : Controller
    {
        private readonly ICommentRepository _CommentRepository;
        private readonly IMapper _mapper;
        public CommentController(ICommentRepository CommentRepository, IMapper mapper)
        {
            _CommentRepository = CommentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Comments = await _CommentRepository.GetAllCommentAsync(); 
            var result = _mapper.Map<List<GetCommentOutputModel>>(Comments); 
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> FilterByUserId(int UserId)
        {
            var Comments = await _CommentRepository.GetCommentByUserIdAsync(UserId);
            ViewBag.SelectedUserName = Comments[0].user.FistName + " " + Comments[0].user.LastName;
            var result = _mapper.Map<List<GetCommentOutputModel>>(Comments);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> FilterByProdId(int ProdId)
        {
            var Comments = await _CommentRepository.GetCommentByProdIdAsync(ProdId);
            ViewBag.SelectedProdName = Comments[0].product.Name;
            var result = _mapper.Map<List<GetCommentOutputModel>>(Comments);
            return View(result);
        }
        //[HttpPost]
        //Delete?UserId=4&ProdId=1013
        [HttpGet]
        public async Task<IActionResult> Delete(int UserId, int ProdId)
        {
            var Comments = await _CommentRepository.GetCommentDetailsAsync(UserId,ProdId);
            //return View(Comments);
            // add by aly
            await _CommentRepository.DeleteCommentAsync(Comments); 
            return RedirectToAction(nameof(Index));
        }
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //} 
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([FromBody] GetCommentOutputModel model)
        //{
        //    try
        //    {
        //        var Comment = _mapper.Map<Comment>(model);
        //        await _CommentRepository.AddCommentAsync(Comment);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}





    }
}
