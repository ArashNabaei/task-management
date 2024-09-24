using task_management.Entities;
using task_management.Persistence;
using task_management.Persistence.Interfaces;
using task_management.Services.Interfaces;

namespace task_management.Services.Implements
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<User?> GetProfile(int id)
        {
            var user = await _profileRepository.GetProfile(id);

            return user;
        }

        public async Task UpdateProfile(int id, User user)
        {
            await _profileRepository.UpdateProfile(id, user);
        }

    }
}
