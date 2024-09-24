using task_management.Entities;

namespace task_management.Persistence.Interfaces
{
    public interface IProfileRepository
    {

        Task<User?> GetProfile(int UserId);

        Task UpdateProfile(int userId, User user);
    }
}
