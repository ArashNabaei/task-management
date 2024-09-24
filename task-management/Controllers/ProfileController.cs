using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using task_management.Entities;
using task_management.Services.Interfaces;

namespace task_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("Profile")]
        public async Task<IActionResult> GetProfile()
        {
            var profile = await _profileService.GetProfile(UserId);

            return Ok(new { Profile = profile });
        }

        [HttpPut("Profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] User user)
        {
            await _profileService.UpdateProfile(UserId, user);

            return Ok();
        }

    }
}
