using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group> GetGroupByIdAsync(int id);
        Task CreateGroupAsync(string name);
        Task UpdateGroupAsync(int id, string name);
        Task SoftDeleteGroupAsync(int id);
    }

    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        // Get All groups
        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            return await _groupRepository.GetAllGroupsAsync();
        }

        // Get group by Id
        public async Task<Group> GetGroupByIdAsync(int id)
        {
            return await _groupRepository.GetGroupByIdAsync(id);
        }

        // Create a Group
        public async Task CreateGroupAsync(string name)
        {
            await _groupRepository.CreateGroupAsync(name);
        }

        // Update a group
        public async Task UpdateGroupAsync(int id, string name)
        {
            try
            {
                await _groupRepository.UpdateGroupAsync(id, name);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        // Delete a group
        public async Task SoftDeleteGroupAsync(int id)
        {
            await _groupRepository.SoftDeleteGroupAsync(id);
        }
    }
}

