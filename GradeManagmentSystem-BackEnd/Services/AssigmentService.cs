using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IAssigmentService
    {
        Task<IEnumerable<Assigment>> GetAllAssigmentsAsync();
        Task<Assigment> GetAssigmentByIdAsync(int id);
        Task CreateAssigmentAsync(string name, string description, DateOnly date, int subjectTeacherId);
        Task UpdateAssigmentAsync(int id, string name, string description, DateOnly date, int subjectTeacherId);
        Task SoftDeleteAssigmentAsync(int id);
    }
    public class AssigmentService : IAssigmentService
    {
        private readonly IAssigmentRepository _assigmentRepository;

        public AssigmentService (IAssigmentRepository assigmentRepository) 
        {
            _assigmentRepository = assigmentRepository;
        }

        //Create Assigment
        public async Task CreateAssigmentAsync(string name, string description, DateOnly date, int subjectTeacherId)
        {
            await _assigmentRepository.CreateAssigmentAsync(name, description, date, subjectTeacherId);
        }

        //Get All Assigment
        public async Task<IEnumerable<Assigment>> GetAllAssigmentsAsync()
        {
            return await _assigmentRepository.GetAllAssigmentsAsync(); 
        }

        //Get Assigment by Id
        public async Task<Assigment> GetAssigmentByIdAsync(int id)
        {
            return await _assigmentRepository.GetAssigmentByIdAsync(id);
        }

        //Delete Assigment
        public async Task SoftDeleteAssigmentAsync(int id)
        {
            await _assigmentRepository.SoftDeleteAssigmentAsync(id);
        }
        //Update Assigment
        public async Task UpdateAssigmentAsync(int id, string name, string description, DateOnly date, int subjectTeacherId)
        {
            try
            {
                await _assigmentRepository.UpdateAssigmentAsync(id, name, description, date, subjectTeacherId);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
