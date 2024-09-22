using task_management.Entities;

namespace task_management.Persistence.Interfaces
{
    public interface IAccountRepository
    {
        Task CreateUser(string username, string password);

        Task<User?> GetUser(string username, string password);
    }
}
