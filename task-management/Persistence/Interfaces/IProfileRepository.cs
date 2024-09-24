using task_management.Entities;

namespace task_management.Persistence.Interfaces
{
    public interface IProfileRepository
    {

        Task<User?> GetProfile(int id);

        Task UpdateProfile(int id, User user);
    }
}
