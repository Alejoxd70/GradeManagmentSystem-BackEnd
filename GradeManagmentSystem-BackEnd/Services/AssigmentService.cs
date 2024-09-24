using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IAssigmentService
    {
        Task<IEnumerable<Assigment>> GetAllAssigmentsAsync();
        Task<Assigment> GetAssigmentByIdAsync(int id);
        Task CreateAssigmentAsync(Assigment assigment);
        Task UpdateAssigmentAsync( Assigment assigment);
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
        public async Task CreateAssigmentAsync(Assigment assigment)
        {
            await _assigmentRepository.CreateAssigmentAsync(assigment);
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
        public async Task UpdateAssigmentAsync(Assigment assigment)
        {
            await _assigmentRepository.UpdateAssigmentAsync(assigment);
        }
    }
}
