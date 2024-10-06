using GradeManagmentSystem_BackEnd.Model;
using GradeManagmentSystem_BackEnd.Repositories;

namespace GradeManagmentSystem_BackEnd.Services
{
    public interface IGroupYearService
    {
        Task<IEnumerable<GroupYear>> GetAllGroupYearsAsync();
        Task <GroupYear> GetGroupYearByIdAsync(int id);
        Task CreateGroupYearAsync (string year, int studentId, int groupId);
        Task UpdateGroupYearAsync (int id, string year, int studentId, int groupId);

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
        public async Task CreateGroupYearAsync(string year, int studentId, int groupId)
        {
            await _groupYearRepository.CreateGroupYearAsync(year, studentId, groupId);
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
        public async Task UpdateGroupYearAsync(int id, string year, int studentId, int groupId)
        {
            try
            {
                await _groupYearRepository.UpdateGroupYearAsync(id, year, studentId, groupId);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
