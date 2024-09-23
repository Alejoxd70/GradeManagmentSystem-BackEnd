using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IAttendantService
    {
        Task<IEnumerable<Attendant>> GetAllAttendantsAsync();
        Task<Attendant> GetAttendantByIdAsync(int id);
        Task CreateAttendantAsync(Attendant attendant);
        Task UpdateAttendantAsync(Attendant attendant);
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
        public async Task CreateAttendantAsync(Attendant attendant)
        {
            await _attendantRepository.CreateAttendantAsync(attendant);
        }

        // Update a attendant
        public async Task UpdateAttendantAsync(Attendant attendant)
        {
            await _attendantRepository.UpdateAttendantAsync(attendant);
        }


        // Delete a attendant
        public async Task SoftDeleteAttendantAsync(int id)
        {
            await _attendantRepository.SoftDeleteAttendantAsync(id);
        }
    }
}
