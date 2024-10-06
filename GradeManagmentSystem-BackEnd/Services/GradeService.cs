using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>> GetAllGradesAsync();
        Task<Grade> GetGradeByIdAsync(int id);
        Task CreateGradeAsync(string value, int assigmentId, int studentId);
        Task UpdateGradeAsync(int id, string value, int assigmentId, int studentId);
        Task SoftDeleteGradeAsync(int id);
    }

    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        // Get All grade
        public async Task<IEnumerable<Grade>> GetAllGradesAsync()
        {
            return await _gradeRepository.GetAllGradesAsync();
        }

        // Get grade by Id
        public async Task<Grade> GetGradeByIdAsync(int id)
        {
            return await _gradeRepository.GetGradeByIdAsync(id);
        }

        // Create a Grade
        public async Task CreateGradeAsync(string value, int assigmentId, int studentId)
        {
            await _gradeRepository.CreateGradeAsync(value, assigmentId, studentId);
        }

        // Update a grade
        public async Task UpdateGradeAsync(int id, string value, int assigmentId, int studentId)
        {
            try
            {
                await _gradeRepository.UpdateGradeAsync(id, value, assigmentId, studentId);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        // Delete a grade
        public async Task SoftDeleteGradeAsync(int id)
        {
            await _gradeRepository.SoftDeleteGradeAsync(id);
        }
    }
}
