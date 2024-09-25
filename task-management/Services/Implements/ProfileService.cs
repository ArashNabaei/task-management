using task_management.Entities;
using task_management.Persistence.Interfaces;
using task_management.Services.Entities;
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

        public async Task<UserDto?> GetProfile(int id)
        {
            var user = await _profileRepository.GetProfile(id);

            var result = ConvertUserToUserDto(user);

            return result;
        }

        public async Task UpdateProfile(int id, UserDto user)
        {
            var result = ConvertUserDtoToUser(user);

            await _profileRepository.UpdateProfile(id, result);
        }

        private static User ConvertUserDtoToUser(UserDto user)
        {
            return new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }

        private static UserDto ConvertUserToUserDto(User? user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }

    }
}
