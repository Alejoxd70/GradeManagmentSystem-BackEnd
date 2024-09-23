using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface IAssigmentRepository
    {
        Task<IEnumerable<Assigment>> GetAllAssigmentsAsync();
        Task<Assigment> GetAssigmentByIdAsync(int id);
        Task CreateAssigmentAsync (Assigment assigment);
        Task UpdateAssigmentAsync(Assigment assigment);

        Task SoftDeleteAssigmentAsync (int id);
    }
    public class AssigmentRepository : IAssigmentRepository
    {
        private readonly AppGradesContext _context;

        public AssigmentRepository(AppGradesContext context)
        {
            _context = context;

        }

        //Create Assigment 
        public async Task CreateAssigmentAsync(Assigment assigment)
        {
            await _context.Assigments.AddAsync(assigment);
            await _context.SaveChangesAsync();
        }

        //Get All Asigments
        public async Task<IEnumerable<Assigment>> GetAllAssigmentsAsync()
        {
            return await _context.Assigments
                .Where(s => !s.IsDeleted) //Excluye eliminados
                .ToListAsync();
        }

        //Get Assigment by Id
        public async Task<Assigment> GetAssigmentByIdAsync(int id)
        {
            return await _context.Assigments
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteAssigmentAsync(int id)
        {
            var assigment = await _context.Assigments.FindAsync(id);
            if (assigment != null)
            {
                assigment.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAssigmentAsync(Assigment assigment)
        {
            _context.Assigments.Update(assigment);
            await _context.SaveChangesAsync();
        }
    }
}
