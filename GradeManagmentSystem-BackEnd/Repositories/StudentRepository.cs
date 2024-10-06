using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{

    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task CreateStudentAsync(string student_code, int userId, int attendantId );
        Task UpdateStudentAsync(int id, string student_code, int userId, int attendantId );
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
                .Include(s => s.User)
                .Include(s => s.Attendant)
                .ToListAsync();
        }

        // Get student by Id
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.AsNoTracking()
                .Include(s => s.User)
                .Include(s => s.Attendant)
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        // Create Student
        public async Task CreateStudentAsync(string student_code, int userId, int attendantId )
        {
            // Fetch the User object based on userId and attendantId
            var user = await _context.Users.FindAsync(userId) ?? throw new Exception("User not found");
            var attendant = await _context.Attendants.FindAsync(attendantId) ?? throw new Exception("Attendant not found");

            // Create a new Student object
            var student = new Student
            {
                Student_code = student_code,
                User = user,
                Attendant = attendant,
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

        }


        // Update Student
        public async Task UpdateStudentAsync(int id, string student_code, int userId, int attendantId  )
        {
            // Find the existing student by ID
            var student = await _context.Students.FindAsync(id) ?? throw new Exception("Student not found");

            // Fetch the User object based on userId and attendantId
            var user = await _context.Users.FindAsync(userId) ?? throw new Exception("User not found");
            var attendant = await _context.Attendants.FindAsync(attendantId) ?? throw new Exception("Attendant not found");

            student.Student_code = student_code;
            student.User = user;
            student.Attendant = attendant;  

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
