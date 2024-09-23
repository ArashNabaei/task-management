using Microsoft.AspNetCore.Mvc;
using task_management.Entities;
using task_management.Services.Interfaces;

namespace task_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(Account user)
        {
            await _accountService.CreateUser(user);

            return Ok("User registered successfully.");
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(Account user)
        {
            var userId = await _accountService.ValidateUser(user.Username, user.Password);

            var token = _accountService.GenerateToken(userId);

            return Ok(new { token });
        }

    }
}
