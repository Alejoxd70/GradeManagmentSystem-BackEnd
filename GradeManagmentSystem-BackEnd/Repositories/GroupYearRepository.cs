using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{

    public interface IGroupYearRepository
    {
        Task<IEnumerable<GroupYear>> GetAllGroupYearsAsync();
        Task<GroupYear> GetGroupYearByIdAsync(int id);
        Task CreateGroupYearAsync(string year, int studentId, int groupId);
        Task UpdateGroupYearAsync(int id, string year, int studentId, int groupId);
        Task SoftDeleteGroupYearAsync(int id);
    }

    public class GroupYearRepository : IGroupYearRepository
    {
        private readonly AppGradesContext _context;

        public GroupYearRepository(AppGradesContext context)
        {
            _context = context;
        }

        //Create GroupYear
        public async Task CreateGroupYearAsync(string year, int studentId, int groupId)
        {
            // Fetch the foreign keys
            var student = await _context.Students.FindAsync(studentId) ?? throw new Exception("Student not found");
            var group = await _context.Groups.FindAsync(groupId) ?? throw new Exception("Group not found");


            var groupYear = new GroupYear
            {
                Year = year,
                Student = student,
                Group = group
            };

            await _context.GroupYears.AddAsync(groupYear);
            await _context.SaveChangesAsync();
        }

        //GetAll GrouoYear
        public async Task<IEnumerable<GroupYear>> GetAllGroupYearsAsync()
        {
            return await _context.GroupYears
               .Where(s => !s.IsDeleted) // Excluye eliminados Avoid deleted items
               .Include(g => g.Student)
               .Include(g => g.Group)
               .ToListAsync();
        }
        
        //Get Group Year by ID
        public async Task<GroupYear> GetGroupYearByIdAsync(int id)
        {
            return await _context.GroupYears.AsNoTracking()
                .Include(g => g.Student)
                .Include(g => g.Group)
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        //Delete Group Year
        public async Task SoftDeleteGroupYearAsync(int id)
        {
            var groupyear = await _context.GroupYears.FindAsync(id);
            if (groupyear != null)
            {
                groupyear.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        //Update Group Year
        public async Task UpdateGroupYearAsync(int id, string year, int studentId, int groupId)
        {
            // Fetch the groupYear
            var groupYear = await _context.GroupYears.FindAsync(id) ?? throw new Exception("Group Year not found");


            // Fetch the foreign keys
            var student = await _context.Students.FindAsync(studentId) ?? throw new Exception("Student not found");
            var group = await _context.Groups.FindAsync(groupId) ?? throw new Exception("Group not found");

            //Update
            groupYear.Year = year;
            groupYear.Student = student;
            groupYear.Group = group;


            try
            {
                _context.GroupYears.Update(groupYear);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;

            }
        }
    }
}
