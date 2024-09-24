using Microsoft.EntityFrameworkCore;
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

        public async Task<User?> GetUser(string username, string password)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Username == username 
                && u.Password == password);

            return user;
        }

    }
}
