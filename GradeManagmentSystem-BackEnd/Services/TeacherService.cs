using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task CreateTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher);
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
        public async Task CreateTeacherAsync(Teacher teacher)
        {
            await _teacherRepository.CreateTeacherAsync(teacher);
        }

        // Update a teacher
        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            try
            {
                await _teacherRepository.UpdateTeacherAsync(teacher);
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
