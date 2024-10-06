using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(string name);
        Task UpdateUserTypeAsync(int id, string name);
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
        public async Task CreateUserTypeAsync(string name)
        {
            var userType = new UserType
            {
                UserTypeName = name,
            };

            await _context.UserTypes.AddAsync(userType);
            await _context.SaveChangesAsync();
        }


        // Update UserType
        public async Task UpdateUserTypeAsync(int id, string name)
        {
            var userType = await _context.UserTypes.FindAsync(id) ?? throw new Exception("UserType not found");

            userType.UserTypeName = name;

            try
            {
                _context.UserTypes.Update(userType);
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
