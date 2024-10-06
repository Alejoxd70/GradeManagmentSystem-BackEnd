using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IPermissionUserTypeService
    {
        Task<IEnumerable<PermissionUserType>> GetAllPermissionUserTypesAsync();
        Task<PermissionUserType> GetPermissionUserTypeByIdAsync(int id);
        Task CreatePermissionUserTypeAsync(int userTypeId, int permissionId);
        Task UpdatePermissionUserTypeAsync(int id, int userTypeId, int permissionId);
        Task SoftDeletePermissionUserTypeAsync(int id);
    }
    public class PermissionUserTypeService : IPermissionUserTypeService
    {
        private readonly IPermissionUserTypeRepository _permissionUserTypeRepository;

        public PermissionUserTypeService(IPermissionUserTypeRepository permissionUserTypeRepository)
        {
            _permissionUserTypeRepository = permissionUserTypeRepository;
        }

        public async Task<IEnumerable<PermissionUserType>> GetAllPermissionUserTypesAsync()
        {
            return await _permissionUserTypeRepository.GetAllPermissionUserTypesAsync();
        }

     
        public async Task<PermissionUserType> GetPermissionUserTypeByIdAsync(int id)
        {
            return await _permissionUserTypeRepository.GetPermissionUserTypeByIdAsync(id);
        }


        public async Task CreatePermissionUserTypeAsync(int userTypeId, int permissionId)
        {
            await _permissionUserTypeRepository.CreatePermissionUserTypeAsync(userTypeId, permissionId);
        }

        public async Task UpdatePermissionUserTypeAsync(int id, int userTypeId, int permissionId)
        {
            
            try
            {
                await _permissionUserTypeRepository.UpdatePermissionUserTypeAsync(id, userTypeId, permissionId);

            }
            catch (Exception e)
            {

                throw;

            }
        }


       
        public async Task SoftDeletePermissionUserTypeAsync(int id)
        {
            await _permissionUserTypeRepository.SoftDeletePermissionUserTypeAsync(id);
        }
    }
}
