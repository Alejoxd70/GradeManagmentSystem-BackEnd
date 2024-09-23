using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task CreateTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher);
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
                .ToListAsync();
        }

        // Get teacher by Id
        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _context.Teachers
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        // Create Teacher
        public async Task CreateTeacherAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }


        // Update Teacher
        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
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
