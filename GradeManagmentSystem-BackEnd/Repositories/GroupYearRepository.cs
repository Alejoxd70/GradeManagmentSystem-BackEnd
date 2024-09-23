using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{

    public interface IGroupYearRepository
    {
        Task<IEnumerable<GroupYear>> GetAllGroupYearsAsync();
        Task<GroupYear> GetGroupYearByIdAsync(int id);
        Task CreateGroupYearAsync(GroupYear groupYear);
        Task UpdateGroupYearAsync(GroupYear groupYear);
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
        public async Task CreateGroupYearAsync(GroupYear groupYear)
        {
            await _context.GroupYears.AddAsync(groupYear);
            await _context.SaveChangesAsync();
        }

        //GetAll GrouoYear
        public async Task<IEnumerable<GroupYear>> GetAllGroupYearsAsync()
        {
            return await _context.GroupYears
               .Where(s => !s.IsDeleted) // Excluye eliminados Avoid deleted items
               .ToListAsync();
        }
        
        //Get Group Year by ID
        public async Task<GroupYear> GetGroupYearByIdAsync(int id)
        {
            return await _context.GroupYears
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
        public async Task UpdateGroupYearAsync(GroupYear groupYear)
        {
            _context.GroupYears.Update(groupYear);
            await _context.SaveChangesAsync();
        }
    }
}
