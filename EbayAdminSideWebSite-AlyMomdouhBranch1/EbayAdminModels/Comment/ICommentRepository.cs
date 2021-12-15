namespace Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommentRepository
    {
        Task<int> AddCommentAsync(Comment Comment); 
        Task<Comment> GetCommentDetailsAsync(int UserId, int ProdId);
        Task<int> UpdateCommentAsync(Comment Comment);
        Task<int> DeleteCommentAsync(Comment Comment);
        /// add by aly 
        Task<List<Comment>> GetAllCommentAsync();
        Task<List<Comment>> GetCommentByUserIdAsync(int id);
        Task<List<Comment>> GetCommentByProdIdAsync(int id);
    }
}
