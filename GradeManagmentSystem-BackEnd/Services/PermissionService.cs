using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
        Task SoftDeletePermissionAsync(int id);
    }
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

   
        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            return await _permissionRepository.GetAllPermissionsAsync();
        }


        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _permissionRepository.GetPermissionByIdAsync(id);
        }


        public async Task CreatePermissionAsync(Permission permission)
        {
            await _permissionRepository.CreatePermissionAsync(permission);
        }

    
        public async Task UpdatePermissionAsync(Permission permission)
        {
            
            try
            {
                await _permissionRepository.UpdatePermissionAsync(permission);

            }
            catch (Exception e)
            {

                throw;

            }
        }


      
        public async Task SoftDeletePermissionAsync(int id)
        {
            await _permissionRepository.SoftDeletePermissionAsync(id);
        }
    }
}
