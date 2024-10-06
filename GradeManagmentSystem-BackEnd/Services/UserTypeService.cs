using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(string name);
        Task UpdateUserTypeAsync(int id, string name);
        Task SoftDeleteUserTypeAsync(int id);
    }

    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeService(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        // Get All UserTypes
        public async Task<IEnumerable<UserType>> GetAllUserTypesAsync()
        {
            return await _userTypeRepository.GetAllUserTypesAsync();
        }

        // Get userType by Id
        public async Task<UserType> GetUserTypeByIdAsync(int id)
        {
            return await _userTypeRepository.GetUserTypeByIdAsync(id);
        }

        // Create a userType
        public async Task CreateUserTypeAsync(string name)
        {
            await _userTypeRepository.CreateUserTypeAsync(name);
        }

        // Update a userType
        public async Task UpdateUserTypeAsync(int id, string name)
        {
            
            try
            {
                await _userTypeRepository.UpdateUserTypeAsync(id, name);

            }
            catch (Exception e)
            {

                throw;

            }
        }


        // Delete a userType
        public async Task SoftDeleteUserTypeAsync(int id)
        {
            await _userTypeRepository.SoftDeleteUserTypeAsync(id);
        }
    }
}
