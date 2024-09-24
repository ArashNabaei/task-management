using task_management.Entities;
using task_management.Persistence.Interfaces;

namespace task_management.Persistence.Repositories
{
    public class ProfileRepository : IProfileRepository
    {

        private readonly EfContext _context;

        public ProfileRepository(EfContext context)
        {
            _context = context;
        }

        public async Task<User?> GetProfile(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }

    }
}
