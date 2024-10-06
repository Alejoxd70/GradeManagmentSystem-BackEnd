using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task CreateTeacherAsync(int userId, string specialitazion);
        Task UpdateTeacherAsync(int id, int userId, string specialitazion);
        Task SoftDeleteTeacherAsync(int id);
    }
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        // Get All Teachers
        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _teacherRepository.GetAllTeachersAsync();
        }

        // Get teacher by Id
        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _teacherRepository.GetTeacherByIdAsync(id);
        }

        // Create a teacher
        public async Task CreateTeacherAsync(int userId, string specialitazion)
        {
            await _teacherRepository.CreateTeacherAsync(userId, specialitazion);
        }

        // Update a teacher
        public async Task UpdateTeacherAsync(int id, int userId, string specialitazion)
        {
            try
            {
                await _teacherRepository.UpdateTeacherAsync(id, userId, specialitazion);
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a teacher
        public async Task SoftDeleteTeacherAsync(int id)
        {
            await _teacherRepository.SoftDeleteTeacherAsync(id);
        }
    }
}
