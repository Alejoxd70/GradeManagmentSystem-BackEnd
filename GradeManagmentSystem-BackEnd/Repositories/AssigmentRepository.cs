using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface IAssigmentRepository
    {
        Task<IEnumerable<Assigment>> GetAllAssigmentsAsync();
        Task<Assigment> GetAssigmentByIdAsync(int id);
        Task CreateAssigmentAsync (string name, string description, DateOnly date, int subjectTeacherId);
        Task UpdateAssigmentAsync(int id, string name, string description, DateOnly date, int subjectTeacherId);

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
        public async Task CreateAssigmentAsync(string name, string description, DateOnly date, int subjectTeacherId)
        {
            // Fetch foreing keys if exist
            var subjectTeacher = await _context.SubjectTeachers.FindAsync(subjectTeacherId) ?? throw new Exception("SubjectTeacher not found");

            var assigment = new Assigment
            {
                Name = name,
                Description = description,
                Date = date,
                SubjectTeacher = subjectTeacher,
            };

            await _context.Assigments.AddAsync(assigment);
            await _context.SaveChangesAsync();
        }

        //Get All Asigments
        public async Task<IEnumerable<Assigment>> GetAllAssigmentsAsync()
        {
            return await _context.Assigments
                .Where(s => !s.IsDeleted) //Excluye eliminados
                .Include(a => a.SubjectTeacher)

                .ToListAsync();
        }

        //Get Assigment by Id
        public async Task<Assigment> GetAssigmentByIdAsync(int id)
        {
            return await _context.Assigments.AsNoTracking()
                .Include(a => a.SubjectTeacher)
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        //Delete Assigment
        public async Task SoftDeleteAssigmentAsync(int id)
        {
            var assigment = await _context.Assigments.FindAsync(id);
            if (assigment != null)
            {
                assigment.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        //Update Assigment
        public async Task UpdateAssigmentAsync(int id, string name, string description, DateOnly date, int subjectTeacherId)
        {
            // Fetch the Assigment
            var assigment = await _context.Assigments.FindAsync(id) ?? throw new Exception("Assigment not found");

            // Fetch foreing keys if exist
            var subjectTeacher = await _context.SubjectTeachers.FindAsync(subjectTeacherId) ?? throw new Exception("SubjectTeacher not found");

            //update
            assigment.Name = name;
            assigment.Description = description;
            assigment.Date = date;  
            assigment.SubjectTeacher = subjectTeacher;

            try
            {
                _context.Assigments.Update(assigment);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }
        }
    }
}
