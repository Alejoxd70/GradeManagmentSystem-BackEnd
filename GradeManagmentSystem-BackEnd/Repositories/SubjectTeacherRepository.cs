using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;
namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface ISubjectTeacherRepository
    {
        Task<IEnumerable<SubjectTeacher>> GeAlltSubjectTeachersAsync();
        Task <SubjectTeacher> GetSubjectTeacherByIdAsync (int id);
        Task CreateSubjectTeacherAsync (int teacherId, int subjectId, int groupYearId);
        Task UpdateSubjectTeacherAsync (int id, int teacherId, int subjectId, int groupYearId);
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
        public async Task CreateSubjectTeacherAsync(int teacherId, int subjectId, int groupYearId)
        {
            // Fetch the ids
            var teacher = await _context.Teachers.FindAsync(teacherId) ?? throw new Exception("Teacher not found");
            var subject = await _context.Subjects.FindAsync(subjectId) ?? throw new Exception("Subject not found");
            var groupYear = await _context.GroupYears.FindAsync(groupYearId) ?? throw new Exception("GroupYear not found");

            var subjectTeacher = new SubjectTeacher
            {
                Teacher = teacher,
                Subject = subject,
                GroupYear = groupYear
            };

            await _context.SubjectTeachers.AddAsync(subjectTeacher);
            await _context.SaveChangesAsync();
        }

        //Get All Subject Teacher
        public async Task<IEnumerable<SubjectTeacher>> GeAlltSubjectTeachersAsync()
        {
            return await _context.SubjectTeachers
                .Where(s => !s.IsDeleted)
                .Include(s => s.Teacher.User)
                .Include(s => s.Subject)
                .Include(s => s.GroupYear.Student.User)
                .Include(s => s.GroupYear.Group)
                .ToListAsync();
        }

        //Get Subject Teacher by Id
        public async Task<SubjectTeacher> GetSubjectTeacherByIdAsync(int id)
        {
            return await _context.SubjectTeachers.AsNoTracking()
                .Include(s => s.Teacher.User)
                .Include(s => s.Subject)
                .Include(s => s.GroupYear.Student.User)
                .Include(s => s.GroupYear.Group)
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
        public async Task UpdateSubjectTeacherAsync(int id, int teacherId, int subjectId, int groupYearId)
        {
            // Fetch the SubjectTeacher Id
            var subjectTeacher = await _context.SubjectTeachers.FindAsync(id) ?? throw new Exception("SubjectTeacher not found");

            // Fetch the foreign keys
            var teacher = await _context.Teachers.FindAsync(teacherId) ?? throw new Exception("Teacher not found");
            var subject = await _context.Subjects.FindAsync(subjectId) ?? throw new Exception("Subject not found");
            var groupYear = await _context.GroupYears.FindAsync(groupYearId) ?? throw new Exception("GroupYear not found");

            // Update
            subjectTeacher.Teacher = teacher;
            subjectTeacher.Subject = subject;
            subjectTeacher.GroupYear = groupYear;

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
