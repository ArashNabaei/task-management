namespace task_management.Persistence.Interfaces
{
    public interface IAccountRepository
    {
        Task CreateUser(string username, string password);

        Task<Entities.User?> GetUser(string username, string password);
    }
}
