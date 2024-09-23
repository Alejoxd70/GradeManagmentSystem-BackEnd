using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IGroupYearService
    {
        Task<IEnumerable<GroupYear>> GetAllGroupYearsAsync();
        Task <GroupYear> GetGroupYearByIdAsync(int id);
        Task CreateGroupYearAsync (GroupYear groupYear);
        Task UpdateGroupYearAsync (GroupYear groupYear);

        Task SoftDeleteGroupYearAsync (int id);
    }
    public class GroupYearService : IGroupYearService
    {
        private readonly IGroupYearRepository _groupYearRepository;

        public GroupYearService(IGroupYearRepository groupYearRepository)
        {
            _groupYearRepository = groupYearRepository;
        }
        //Create GroupYear
        public async Task CreateGroupYearAsync(GroupYear groupYear)
        {
            await _groupYearRepository.CreateGroupYearAsync(groupYear);
        }

        //Get All GroupYear
        public async Task<IEnumerable<GroupYear>> GetAllGroupYearsAsync()
        {
            return await _groupYearRepository.GetAllGroupYearsAsync();
        }

        //Get GroupYear By Id
        public async Task<GroupYear> GetGroupYearByIdAsync(int id)
        {
            return await _groupYearRepository.GetGroupYearByIdAsync(id);
        }

        // Delete GroupYear
        public async Task SoftDeleteGroupYearAsync(int id)
        {
            await _groupYearRepository.SoftDeleteGroupYearAsync(id);
        }

        //Update GroupYear
        public async Task UpdateGroupYearAsync(GroupYear groupYear)
        {
            await _groupYearRepository.UpdateGroupYearAsync(groupYear);
        }
    }
}
