using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{

    public interface IPermissionUserTypeRepository
    {
        Task<IEnumerable<PermissionUserType>> GetAllPermissionUserTypesAsync();
        Task<PermissionUserType> GetPermissionUserTypeByIdAsync(int id);
        Task CreatePermissionUserTypeAsync(int userTypeId, int permissionId);
        Task UpdatePermissionUserTypeAsync(int id, int userTypeId, int permissionId);
        Task SoftDeletePermissionUserTypeAsync(int id);
        Task <bool> HasPermissionAsync(int userTypeId, int permissionId);
    }
    public class PermissionUserTypeRepository : IPermissionUserTypeRepository
    {
        private readonly AppGradesContext _context;

        public PermissionUserTypeRepository(AppGradesContext context)
        {
            _context = context;
        }

        // Get all PermissionUserTypes
        public async Task<IEnumerable<PermissionUserType>> GetAllPermissionUserTypesAsync()
        {
            return await _context.PermissionUserTypes
                .Where(s => !s.IsDeleted) // Avoid deleted items
                .Include(p => p.UserType)
                .Include(p => p.Permission)
                .ToListAsync();
        }

        // Get a PermissionUserType by a Id
        public async Task<PermissionUserType> GetPermissionUserTypeByIdAsync(int id)
        {
            return await _context.PermissionUserTypes.AsNoTracking()
                .Include(p => p.UserType)
                .Include(p => p.Permission)
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        // Create a PermissionUserType
        public async Task CreatePermissionUserTypeAsync(int userTypeId, int permissionId)
        {
            // Fetch foreing keys if exists
            var userType = await _context.UserTypes.FindAsync(userTypeId) ?? throw new Exception("UserType not found");
            var permission = await _context.Permissions.FindAsync(permissionId) ?? throw new Exception("Permission not found");

            var permissionUserType = new PermissionUserType
            {
                Permission = permission,
                UserType = userType
            };

            await _context.PermissionUserTypes.AddAsync(permissionUserType);
            await _context.SaveChangesAsync();
        }


        // Update a PermissionUserType
        public async Task UpdatePermissionUserTypeAsync(int id, int userTypeId, int permissionId)
        {
            // Fetch the UserType
            var permissionUserType = await _context.PermissionUserTypes.FindAsync(id) ?? throw new Exception("PermissionUserType not found");

            // Fetch foreing keys if exists
            var userType = await _context.UserTypes.FindAsync(userTypeId) ?? throw new Exception("UserType not found");
            var permission = await _context.Permissions.FindAsync(permissionId) ?? throw new Exception("UserType not found");

            permissionUserType.Permission = permission;
            permissionUserType.UserType = userType;


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

        // delete a PermissionUserType
        public async Task SoftDeletePermissionUserTypeAsync(int id)
        {
            var permissionUserType = await _context.PermissionUserTypes.FindAsync(id);
            if (permissionUserType != null)
            {
                permissionUserType.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }

        // Validate if has permissions
        public async Task<bool> HasPermissionAsync(int userTypeId, int permissionId)
        {
            var permission = await _context.PermissionUserTypes
            .Where(p => p.UserType.Id == userTypeId && p.Permission.Id == permissionId && !p.IsDeleted)
            .FirstOrDefaultAsync();

            return permission != null ? true : false;
        }
    }
}