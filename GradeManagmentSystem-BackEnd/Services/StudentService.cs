using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{   

    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task CreateStudentAsync(string student_code, int userId, int attendantId );
        Task UpdateStudentAsync(int id, string student_code, int userId, int attendantId );
        Task SoftDeleteStudentAsync(int id);
    }
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // Get All Students
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        // Get student by Id
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }

        // Create a student
        public async Task CreateStudentAsync(string student_code,int userId, int attendantId )
        {
            await _studentRepository.CreateStudentAsync(student_code, userId, attendantId );
        }

        // Update a student
        public async Task UpdateStudentAsync(int id, string student_code, int userId, int attendantId )
        {
            try
            {
                await _studentRepository.UpdateStudentAsync(id, student_code, userId, attendantId );
            }
            catch (Exception e)
            {

                throw;
            }
        }


        // Delete a student
        public async Task SoftDeleteStudentAsync(int id)
        {
            await _studentRepository.SoftDeleteStudentAsync(id);
        }
    }
}
