using task_management.Entities;
using task_management.Persistence.Interfaces;
using task_management.Services.Interfaces;

namespace task_management.Services.Implements
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
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

    }
}
