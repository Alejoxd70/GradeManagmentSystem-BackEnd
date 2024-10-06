using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IAttendantService
    {
        Task<IEnumerable<Attendant>> GetAllAttendantsAsync();
        Task<Attendant> GetAttendantByIdAsync(int id);
        Task CreateAttendantAsync(string name, string lastName, string relationship);
        Task UpdateAttendantAsync(int id, string name, string lastName, string relationship);
        Task SoftDeleteAttendantAsync(int id);
    }

    public class AttendantService : IAttendantService
    {
        private readonly IAttendantRepository _attendantRepository;

        public AttendantService(IAttendantRepository attendantRepository)
        {
            _attendantRepository = attendantRepository;
        }

        // Get All Attendants
        public async Task<IEnumerable<Attendant>> GetAllAttendantsAsync()
        {
            return await _attendantRepository.GetAllAttendantsAsync();
        }

        // Get attendant by Id
        public async Task<Attendant> GetAttendantByIdAsync(int id)
        {
            return await _attendantRepository.GetAttendantByIdAsync(id);
        }

        // Create a attendant
        public async Task CreateAttendantAsync(string name, string lastName, string relationship)
        {
            await _attendantRepository.CreateAttendantAsync(name, lastName, relationship);
        }

        // Update a attendant
        public async Task UpdateAttendantAsync(int id, string name, string lastName, string relationship)
        {
            try
            {
                await _attendantRepository.UpdateAttendantAsync(id, name, lastName, relationship);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        // Delete a attendant
        public async Task SoftDeleteAttendantAsync(int id)
        {
            await _attendantRepository.SoftDeleteAttendantAsync(id);
        }
    }
}
