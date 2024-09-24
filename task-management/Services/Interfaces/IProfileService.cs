using task_management.Entities;

namespace task_management.Services.Interfaces
{
    public interface IProfileService
    {
        Task<User?> GetUser(int id);

        Task UpdateUser(int id, User user);
    }
}
