using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAllGradesAsync();
        Task<Grade> GetGradeByIdAsync(int id);
        Task CreateGradeAsync(string value, int assigmentId, int studentId);
        Task UpdateGradeAsync(int id, string value, int assigmentId, int studentId);
        Task SoftDeleteGradeAsync(int id);
    }
    public class GradeRepository : IGradeRepository
    {
        private readonly AppGradesContext _context;

        public GradeRepository(AppGradesContext context)
        {
            _context = context;
        }

        // Get all grades
        public async Task<IEnumerable<Grade>> GetAllGradesAsync()
        {
            return await _context.Grades
                .Where(s => !s.IsDeleted) // Avoid deleted items
                .Include(g => g.Student)
                .Include(g => g.Assigment)
                .ToListAsync();
        }

        // Get grade by Id
        public async Task<Grade> GetGradeByIdAsync(int id)
        {
            return await _context.Grades.AsNoTracking()
                .Include(g => g.Student)
                .Include(g => g.Assigment)
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        // Create grade
        public async Task CreateGradeAsync(string value, int assigmentId, int studentId)
        {
            // Fetch foreign keys if exist
            var assigment = await _context.Assigments.FindAsync(assigmentId) ?? throw new Exception("Assigment not found");
            var student = await _context.Students.FindAsync(studentId) ?? throw new Exception("Student not found");

            var grade = new Grade
            {
                Value = value,
                Assigment = assigment,
                Student = student,
            };

            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
        }


        // Update grade
        public async Task UpdateGradeAsync(int id, string value, int assigmentId, int studentId)
        {
            // Fetch grade
            var grade = await _context.Grades.FindAsync(id) ?? throw new Exception("Grade not found");

            // Fetch foreign keys if exist
            var assigment = await _context.Assigments.FindAsync(assigmentId) ?? throw new Exception("Assigment not found");
            var student = await _context.Students.FindAsync(studentId) ?? throw new Exception("Student not found");

            grade.Student = student;
            grade.Assigment = assigment;
            grade.Value = value;


            try
            {
                _context.Grades.Update(grade);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
       
        }


        // Delete grade
        public async Task SoftDeleteGradeAsync(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade != null)
            {
                grade.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}
