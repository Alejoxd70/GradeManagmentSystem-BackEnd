using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync (string name, string lastName, string email, string password, string identification, int userTypeId);
        Task UpdateUserAsync (int id, string name, string lastName, string email, string password, string identification, int userTypeId);
        Task SoftDeleteUserAsync (int id);
        Task<bool> ValidateUserAsync(string email, string password);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AppGradesContext _context;

        public UserRepository(AppGradesContext context)
        {
            _context = context;
        }

        // Get all users
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Where(s => !s.IsDeleted) // Avoid deleted items
                .Include(u => u.UserType)
                .ToListAsync();
        }

        // Get user by Id
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.AsNoTracking()
                .Include(u => u.UserType)
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        // Create User
        public async Task CreateUserAsync(string name, string lastName, string email, string password, string identification, int userTypeId)
        {
            // Fetch the UserType
            var userType = await _context.UserTypes.FindAsync(userTypeId) ?? throw new Exception("UserType not found");

            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(null, password);

            // Create a new User object
            var user = new User
            {
                Name = name,
                LastName = lastName,
                Email = email,
                Password = hashedPassword,
                Identification = identification,
                UserType = userType
            };

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

            } 
            catch (Exception ex)
            {
                throw;
            }
        }


        // Update User
        public async Task UpdateUserAsync(int id, string name, string lastName, string email, string password, string identification, int userTypeId)
        {
            // Find the existing user by ID
            var user = await _context.Users.FindAsync(id) ?? throw new Exception("User not found");

            // Fetch the User object based on userId and attendantId
            var userType = await _context.UserTypes.FindAsync(userTypeId) ?? throw new Exception("UserType not found");

            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(user, password);

            // Update
            user.Name = name;
            user.LastName = lastName;
            user.Email = email;
            user.Password = hashedPassword;
            user.Identification = identification;
            user.UserType = userType;


            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }
        }

        // Delete user
        public async Task SoftDeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }

        // Check user password and email
        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            // Fetch the user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception("User not found");

            // User does not exist
            if (user == null) return false;
     
            // Initialize PasswordHasher
            var passwordHasher = new PasswordHasher<User>();

            // Verify the password
            var userVerification = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            // Check if password is correct
            if (userVerification  == PasswordVerificationResult.Success) return true;

            // Password is invalid
            return false;
        }
    }
}
