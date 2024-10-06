using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task CreateTeacherAsync(int userId, string specialitazion);
        Task UpdateTeacherAsync(int id, int userId, string specialitazion);
        Task SoftDeleteTeacherAsync(int id);
    }
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppGradesContext _context;

        public TeacherRepository(AppGradesContext context)
        {
            _context = context;
        }

        // Get all Teachers
        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _context.Teachers
                .Where(s => !s.IsDeleted) // Avoid deleted items
                .Include(t => t.User)
                .ToListAsync();
        }

        // Get teacher by Id
        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _context.Teachers.AsNoTracking()
                .Include(t => t.User)
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        // Create Teacher
        public async Task CreateTeacherAsync(int userId, string specialitazion)
        {
            // Fetch the User
            var user = await _context.Users.FindAsync(userId) ?? throw new Exception("User not found");

            // Create a new Teacher object
            var teacher = new Teacher
            {
                User = user,
                Specialization = specialitazion
            };

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }


        // Update Teacher
        public async Task UpdateTeacherAsync(int id, int userId, string specialitazion)
        {
            // Fetch the Teacher
            var teacher = await _context.Teachers.FindAsync(id) ?? throw new Exception("Teacher not found");

            // Fetch the foreign keys
            var user = await _context.Users.FindAsync(userId) ?? throw new Exception("User not found");

            // Update
            teacher.User = user;
            teacher.Specialization = specialitazion;

            try
            {
                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }
        }

        // Delete teacher
        public async Task SoftDeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                teacher.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
