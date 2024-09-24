using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{

    public interface ISubjectTeacherService
    {
        Task<IEnumerable<SubjectTeacher>> GetAllSubjectTeachersAsync();
        Task<SubjectTeacher> GetSubjectTeacherByIdAsync(int id);
        Task CreateeSubjectTeacherAsync(SubjectTeacher subjectTeacher);
        Task UpdateSubjectTeacherAsync(SubjectTeacher subjectTeacher);
        Task SoftDeleteSubjectTeacherAsync(int id);

        public class SubjectTeacherService : ISubjectTeacherService
        {
            private readonly ISubjectTeacherRepository _subjectTeacherRepository;
            public SubjectTeacherService(ISubjectTeacherRepository subjectTeacherRepository)
            {
                _subjectTeacherRepository = subjectTeacherRepository;
            }

            //Create SubjectTeacher
            public async Task CreateeSubjectTeacherAsync(SubjectTeacher subjectTeacher)
            {
                await _subjectTeacherRepository.CreateSubjectTeacherAsync(subjectTeacher);
            }

            //Get All SubjectTeacher
            public async Task<IEnumerable<SubjectTeacher>> GetAllSubjectTeachersAsync()
            {
                return await _subjectTeacherRepository.GeAlltSubjectTeachersAsync();
            }

            //Get SubjectTeacher
            public async Task<SubjectTeacher> GetSubjectTeacherByIdAsync(int id)
            {
                return await _subjectTeacherRepository.GetSubjectTeacherByIdAsync(id);
            }

            //Delete  SubjectTeacher
            public async Task SoftDeleteSubjectTeacherAsync(int id)
            {
                await _subjectTeacherRepository.SoftDeleteSubjectTeacherAsync(id);
            }

            //Update SubjectTeacher
            public async Task UpdateSubjectTeacherAsync(SubjectTeacher subjectTeacher)
            {
                
                try
                {
                    await _subjectTeacherRepository.UpdateSubjectTeacherAsync(subjectTeacher);
                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }
    }
}