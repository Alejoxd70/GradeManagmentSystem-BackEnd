using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<Subject> GetSubjectByIdAsync(int id);
        Task CreateSubjectAsync(Subject subject);
        Task UpdateSubjectAsync(Subject subject);
        Task SoftDeleteSubjectAsync(int id);
    }
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppGradesContext _context;

        public SubjectRepository(AppGradesContext context)
        {
            _context = context;
        }

        // Get all subjects
        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects
                .Where(s => !s.IsDeleted) // Avoid deleted items
                .ToListAsync();
        }

        // Get subjects by Id
        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _context.Subjects.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        // Create subject
        public async Task CreateSubjectAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }


        // Update subject
        public async Task UpdateSubjectAsync(Subject subject)
        {
            try
            {
                _context.Subjects.Update(subject);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }


        // Delete subject
        public async Task SoftDeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                subject.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}

