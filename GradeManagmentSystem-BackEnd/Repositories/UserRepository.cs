using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync (User user);
        Task UpdateUserAsync (User user);
        Task SoftDeleteUserAsync (int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AppGradesContext _context;

        public UserRepository(AppGradesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Where(s => !s.IsDeleted) // Avoid deleted items
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}
