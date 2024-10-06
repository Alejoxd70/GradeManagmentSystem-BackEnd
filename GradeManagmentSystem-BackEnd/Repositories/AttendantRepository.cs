using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface IAttendantRepository
    {
        Task<IEnumerable<Attendant>> GetAllAttendantsAsync();
        Task<Attendant> GetAttendantByIdAsync(int id);
        Task CreateAttendantAsync(string name, string lastName, string relationship);
        Task UpdateAttendantAsync(int id, string name, string lastName, string relationship);
        Task SoftDeleteAttendantAsync(int id);
    }
    public class AttendantRepository : IAttendantRepository
    {
        private readonly AppGradesContext _context;

        public AttendantRepository(AppGradesContext context)
        {
            _context = context;
        }

        // Get all Attendants
        public async Task<IEnumerable<Attendant>> GetAllAttendantsAsync()
        {
            return await _context.Attendants
                .Where(s => !s.IsDeleted) // Avoid deleted items
                .ToListAsync();
        }

        // Get attendant by Id
        public async Task<Attendant> GetAttendantByIdAsync(int id)
        {
            return await _context.Attendants.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        // Create Attendant
        public async Task CreateAttendantAsync(string name, string lastName, string relationship)
        {
            var attendant = new Attendant
            {
                Name = name,
                LastName = lastName,
                Relationship = relationship
            };

            await _context.Attendants.AddAsync(attendant);
            await _context.SaveChangesAsync();
        }


        // Update Attendant
        public async Task UpdateAttendantAsync(int id, string name, string lastName, string relationship)
        {
            var attendant = await _context.Attendants.FindAsync(id) ?? throw new Exception("Attendant not found");

            attendant.LastName = lastName;
            attendant.Relationship = relationship;
            attendant.Name = name;

            try
            {
                _context.Attendants.Update(attendant);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }
        }


        // Delete attendant
        public async Task SoftDeleteAttendantAsync(int id)
        {
            var attendant = await _context.Attendants.FindAsync(id);
            if (attendant != null)
            {
                attendant.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

        }
    }
}
