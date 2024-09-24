using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(UserType usertype);
        Task UpdateUserTypeAsync(UserType usertype);
        Task SoftDeleteUserTypeAsync(int id);
    }

    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly AppGradesContext _context;

        public UserTypeRepository(AppGradesContext context)
        {
            _context = context;
        }

        // Get all usertypes
        public async Task<IEnumerable<UserType>> GetAllUserTypesAsync()
        {
            return await _context.UserTypes
                .Where(s => !s.IsDeleted) // Avoid deleted items
                .ToListAsync();
        }

        // Get usertype by Id
        public async Task<UserType> GetUserTypeByIdAsync(int id)
        {
            return await _context.UserTypes.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        // Create UserType
        public async Task CreateUserTypeAsync(UserType usertype)
        {
            await _context.UserTypes.AddAsync(usertype);
            await _context.SaveChangesAsync();
        }


        // Update UserType
        public async Task UpdateUserTypeAsync(UserType usertype)
        {
            
            try
            {
                _context.UserTypes.Update(usertype);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw;

            }
        }


        // Delete usertype
        public async Task SoftDeleteUserTypeAsync(int id)
        {
            var usertype = await _context.UserTypes.FindAsync(id);
            if (usertype != null)
            {
                usertype.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}
