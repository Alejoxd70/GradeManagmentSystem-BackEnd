using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{

    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task CreateStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task SoftDeleteStudentAsync(int id);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly AppGradesContext _context;

        public StudentRepository(AppGradesContext context)
        {
            _context = context;
        }

        // Get all Students
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Where(s => !s.IsDeleted) // Avoid deleted items
                .ToListAsync();
        }

        // Get student by Id
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        // Create Student
        public async Task CreateStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }


        // Update Student
        public async Task UpdateStudentAsync(Student student)
        {
            try
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }


        // Delete student
        public async Task SoftDeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                student.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }

    }
}
