using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{

    public interface IPermissionUserTypeRepository
    {
        Task<IEnumerable<PermissionUserType>> GetAllPermissionUserTypesAsync();
        Task<PermissionUserType> GetPermissionUserTypeByIdAsync(int id);
        Task CreatePermissionUserTypeAsync(PermissionUserType permissionUserType);
        Task UpdatePermissionUserTypeAsync(PermissionUserType permissionUserType);
        Task SoftDeletePermissionUserTypeAsync(int id);
    }
    public class PermissionUserTypeRepository : IPermissionUserTypeRepository
    {
        private readonly AppGradesContext _context;

        public PermissionUserTypeRepository(AppGradesContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<PermissionUserType>> GetAllPermissionUserTypesAsync()
        {
            return await _context.PermissionUserTypes
                .Where(s => !s.IsDeleted) // Avoid deleted items
                .ToListAsync();
        }

        
        public async Task<PermissionUserType> GetPermissionUserTypeByIdAsync(int id)
        {
            return await _context.PermissionUserTypes.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        
        public async Task CreatePermissionUserTypeAsync(PermissionUserType permissionUserType)
        {
            await _context.PermissionUserTypes.AddAsync(permissionUserType);
            await _context.SaveChangesAsync();
        }


        
        public async Task UpdatePermissionUserTypeAsync(PermissionUserType permissionUserType)
        {
            
            try
            {
                _context.PermissionUserTypes.Update(permissionUserType);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw;

            }
        }


        
        public async Task SoftDeletePermissionUserTypeAsync(int id)
        {
            var permissionUserType = await _context.PermissionUserTypes.FindAsync(id);
            if (permissionUserType != null)
            {
                permissionUserType.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}