using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int id);
        Task CreateUserTypeAsync(UserType userType);
        Task UpdateUserTypeAsync(UserType userType);
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
        public async Task CreateUserTypeAsync(UserType userType)
        {
            await _userTypeRepository.CreateUserTypeAsync(userType);
        }

        // Update a userType
        public async Task UpdateUserTypeAsync(UserType userType)
        {
            
            try
            {
                await _userTypeRepository.UpdateUserTypeAsync(userType);

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
