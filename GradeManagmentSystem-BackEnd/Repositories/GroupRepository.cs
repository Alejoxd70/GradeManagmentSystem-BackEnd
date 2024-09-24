using GradeManagmentSystem_BackEnd.Context;
using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace GradeManagmentSystem_BackEnd.Repositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group> GetGroupByIdAsync(int id);
        Task CreateGroupAsync(Group group);
        Task UpdateGroupAsync(Group group);
        Task SoftDeleteGroupAsync(int id);
    }
    public class GroupRepository : IGroupRepository
    {
            private readonly AppGradesContext _context;

            public GroupRepository(AppGradesContext context)
            {
                _context = context;
            }

            // Get all groups
            public async Task<IEnumerable<Group>> GetAllGroupsAsync()
            {
                return await _context.Groups
                    .Where(s => !s.IsDeleted) // Avoid deleted items
                    .ToListAsync();
            }

            // Get group by Id
            public async Task<Group> GetGroupByIdAsync(int id)
            {
                return await _context.Groups.AsNoTracking()
                    .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
            }

            // Create group
            public async Task CreateGroupAsync(Group group)
            {
                await _context.Groups.AddAsync(group);
                await _context.SaveChangesAsync();
            }


            // Update group
            public async Task UpdateGroupAsync(Group group)
            {
            try
            {
                _context.Groups.Update(group);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            } 
            }


            // Delete group
            public async Task SoftDeleteGroupAsync(int id)
            {
                var group = await _context.Groups.FindAsync(id);
                if (group != null)
                {
                    group.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }

            }
    }
}
