using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{

    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
        Task SoftDeletePermissionAsync(int id);
    }
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppGradesContext _context;

        public PermissionRepository(AppGradesContext context)
        {
            _context = context;
        }

       
        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            return await _context.Permissions
                .Where(s => !s.IsDeleted) // Avoid deleted items
                .ToListAsync();
        }


        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _context.Permissions.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        
        public async Task CreatePermissionAsync(Permission permission)
        {
            await _context.Permissions.AddAsync(permission);
            await _context.SaveChangesAsync();
        }


        public async Task UpdatePermissionAsync(Permission permission)
        {
            
            try
            {
                _context.Permissions.Update(permission);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw;

            }
        }



       
        public async Task SoftDeletePermissionAsync(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission != null)
            {
                permission.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}
