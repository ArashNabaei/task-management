using task_management.Entities;
using task_management.Persistence.Interfaces;

namespace task_management.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EfContext _context;

        public AccountRepository(EfContext context)
        {
            _context = context;
        }

        public async Task CreateUser(string username, string password)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }

    }
}
