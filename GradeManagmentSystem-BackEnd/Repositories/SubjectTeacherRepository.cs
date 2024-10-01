using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;
namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface ISubjectTeacherRepository
    {
        Task<IEnumerable<SubjectTeacher>> GeAlltSubjectTeachersAsync();
        Task <SubjectTeacher> GetSubjectTeacherByIdAsync (int id);
        Task CreateSubjectTeacherAsync (SubjectTeacher subjectTeacher);
        Task UpdateSubjectTeacherAsync (SubjectTeacher subjectTeacher);
        Task SoftDeleteSubjectTeacherAsync (int id);
    }
    public class SubjectTeacherRepository : ISubjectTeacherRepository
    {
        private readonly AppGradesContext _context;

        public SubjectTeacherRepository(AppGradesContext context)
        {
            _context = context;
        }


        //Create SubjectTeacher
        public async Task CreateSubjectTeacherAsync(SubjectTeacher subjectTeacher)
        {
            await _context.SubjectTeachers.AddAsync(subjectTeacher);
            await _context.SaveChangesAsync();
        }

        //Get All Subject Teacher
        public async Task<IEnumerable<SubjectTeacher>> GeAlltSubjectTeachersAsync()
        {
            return await _context.SubjectTeachers
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        //Get Subject Teacher by Id
        public async Task<SubjectTeacher> GetSubjectTeacherByIdAsync(int id)
        {
            return await _context.SubjectTeachers.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        //Delete Subject Teacher
        public async Task SoftDeleteSubjectTeacherAsync(int id)
        {
            var subjectteacher = await _context.SubjectTeachers.FindAsync(id);
            if (subjectteacher != null)
            {
                subjectteacher.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        //Update Subject Teacher
        public async Task UpdateSubjectTeacherAsync(SubjectTeacher subjectTeacher)
        {
            try
            {
                _context.SubjectTeachers.Update(subjectTeacher);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }
        }
    }
}
