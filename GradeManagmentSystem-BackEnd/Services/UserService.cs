using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(string name, string lastName, string email, string password, string identification, int userTypeId);
        Task UpdateUserAsync(int id, string name, string lastName, string email, string? password, string identification , int userTypeId);
        Task SoftDeleteUserAsync(int id);
        Task<User> ValidateUserAsync(string email, string password);

    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Get All Users
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        // Get user by Id
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        // Create a user
        public async Task CreateUserAsync(string name, string lastName, string email, string password, string identification, int userTypeId)
        {
            await _userRepository.CreateUserAsync(name, lastName, email, password, identification, userTypeId);
        }

        // Update a user
        public async Task UpdateUserAsync(int id, string name, string lastName, string email, string? password, string identification, int userTypeId)
        {
            try
            {
                await _userRepository.UpdateUserAsync(id, name, lastName, email, password, identification, userTypeId);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a user
        public async Task SoftDeleteUserAsync(int id)
        {
            await _userRepository.SoftDeleteUserAsync(id);
        }

        // validate user
        public async Task<User> ValidateUserAsync(string email, string password)
        {
            try
            {
                return await _userRepository.ValidateUserAsync(email, password);    
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
