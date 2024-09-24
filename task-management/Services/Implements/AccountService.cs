using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using task_management.Entities;
using task_management.Persistence.Interfaces;
using task_management.Services.Interfaces;

namespace task_management.Services.Implements
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;

        private readonly IConfiguration _configuration;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        public async Task CreateUser(Account user)
        {
            var username = user.Username;
            var password = user.Password;

            var existingUser = await _accountRepository.GetUser(username, password);

            if (existingUser != null)
                throw new Exception("User already exists.");

            await _accountRepository.CreateUser(username, password);
        }

        public async Task<int> ValidateUser(string username, string password)
        {
            var user = await _accountRepository.GetUser(username, password);

            if (user == null)
                throw new Exception("The username or password does not exist.");
            return user.Id;
        }

        public string GenerateToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                }),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<double>("Jwt:ExpiryMinutes")),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
