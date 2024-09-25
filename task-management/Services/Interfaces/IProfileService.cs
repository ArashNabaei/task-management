using task_management.Services.Entities;

namespace task_management.Services.Interfaces
{
    public interface IProfileService
    {
        Task<UserDto?> GetProfile(int id);

        Task UpdateProfile(int id, UserDto user);
    }
}
