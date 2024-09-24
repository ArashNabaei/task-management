using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using task_management.Persistence;
using task_management.Persistence.Interfaces;
using task_management.Persistence.Repositories;
using task_management.Services.Implements;
using task_management.Services.Interfaces;

namespace task_management.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EfContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProfileService, ProfileService>();

            return services;
        }

    }
}
