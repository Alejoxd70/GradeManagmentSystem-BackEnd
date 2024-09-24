using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>> GetAllGradesAsync();
        Task<Grade> GetGradeByIdAsync(int id);
        Task CreateGradeAsync(Grade grade);
        Task UpdateGradeAsync(Grade grade);
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
        public async Task CreateGradeAsync(Grade grade)
        {
            await _gradeRepository.CreateGradeAsync(grade);
        }

        // Update a grade
        public async Task UpdateGradeAsync(Grade grade)
        {
            try
            {
                await _gradeRepository.UpdateGradeAsync(grade);
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
