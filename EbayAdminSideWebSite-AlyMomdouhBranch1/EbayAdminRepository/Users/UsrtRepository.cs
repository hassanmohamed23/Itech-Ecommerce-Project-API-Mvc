namespace EbayAdminRepository.Users
{
    using EbayAdminDbContext;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {
        private readonly myDbContext _context;
        public UserRepository(myDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddUserAsync(User User)
        {
            await _context.Users.AddAsync(User); 
            await _context.SaveChangesAsync(); 
            return User.Id;
        }

        public async Task<int> DeleteUserAsync(User User)
        {
            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
            return User.Id;
        }

        public async Task<User> GetUserDetailsAsync(int value)
        {
            return await _context.Users.Where(c => c.Id == value).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUserAsync()
        {
            //return await _context.Users.ToListAsync();
            return await _context.Users.ToListAsync();
        }

        public async Task<int> UpdateUserAsync(User User)
        {
            _context.Update(User);
            await _context.SaveChangesAsync();
            return User.Id;
        }
        ///    aly add password hash and this nevor login  
        public async Task<User> GetUserAsync(string userName, string password)
        {
            return await _context.Users // here PasswordHash
                .Where(u => u.PasswordHash == password && u.UserName == userName).FirstOrDefaultAsync();
        }
    }
}
