namespace EbayAdminRepository.Admins
{
    using EbayAdminDbContext;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminRepository : IAdminRepository
    {
        private readonly myDbContext _context;
        public AdminRepository(myDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAdminAsync(Admin Admin)
        {
            await _context.Admins.AddAsync(Admin);

            await _context.SaveChangesAsync();


            return Admin.AdminId;
        }

        public async Task<int> DeleteAdminAsync(Admin Admin)
        {
            _context.Admins.Remove(Admin);
            await _context.SaveChangesAsync();
            return Admin.AdminId;
        }

        public async Task<Admin> GetAdminDetailsAsync(int value)
        {
            return await _context.Admins.Where(c => c.AdminId == value).FirstOrDefaultAsync();
        }

        public async Task<List<Admin>> GetAdminAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<int> UpdateAdminAsync(Admin Admin)
        {
            _context.Update(Admin);
            await _context.SaveChangesAsync();
            return Admin.AdminId;
        }
        public async Task<Admin> findadminlogin(string email, string password)
        {
            return await _context.Admins 
                .Where(a => a.Password == password && a.Email == email).FirstOrDefaultAsync();
        }

    }
}
