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

        public async Task UpdateProfile(int id, User user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            
            UpdateUserFields(user, existingUser);

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
        }

        private static void UpdateUserFields(User user, User existingUser)
        {
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
        }

    }
}
