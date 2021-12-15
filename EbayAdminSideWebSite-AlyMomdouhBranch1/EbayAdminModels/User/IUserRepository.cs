namespace Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserRepository
    {
        Task<int> AddUserAsync(User User);
        Task<List<User>> GetUserAsync();
        Task<User> GetUserDetailsAsync(int value);
        Task<int> UpdateUserAsync(User User);
        Task<int> DeleteUserAsync(User User);
        Task<User> GetUserAsync(string userName, string password);
    }
}
