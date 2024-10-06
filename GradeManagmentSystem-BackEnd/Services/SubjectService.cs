using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<Subject> GetSubjectByIdAsync(int id);
        Task CreateSubjectAsync(string name, string description);
        Task UpdateSubjectAsync(int id, string name, string description);
        Task SoftDeleteSubjectAsync(int id);
    }

    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        // Get All subjects
        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _subjectRepository.GetAllSubjectsAsync();
        }

        // Get subject by Id
        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _subjectRepository.GetSubjectByIdAsync(id);
        }

        // Create a Subject
        public async Task CreateSubjectAsync(string name, string description)
        {
            await _subjectRepository.CreateSubjectAsync(name, description);
        }

        // Update a subject
        public async Task UpdateSubjectAsync(int id, string name, string description)
        {
            try
            {
                await _subjectRepository.UpdateSubjectAsync(id, name, description);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        // Delete a subject
        public async Task SoftDeleteSubjectAsync(int id)
        {
            await _subjectRepository.SoftDeleteSubjectAsync(id);
        }
    }
}
