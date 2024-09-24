using task_management.Entities;

namespace task_management.Services.Interfaces
{
    public interface IAccountService
    {
        Task CreateUser(Account user);

        string GenerateToken(int userId);

        Task<int> ValidateUser(string username, string password);
    }
}
