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
        Task CreateGradeAsync(Grade grade);
        Task UpdateGradeAsync(Grade grade);
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
                .ToListAsync();
        }

        // Get grade by Id
        public async Task<Grade> GetGradeByIdAsync(int id)
        {
            return await _context.Grades.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        // Create grade
        public async Task CreateGradeAsync(Grade grade)
        {
            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
        }


        // Update grade
        public async Task UpdateGradeAsync(Grade grade)
        {
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
