using Application.Concretes;
using Application.Contracts;
using Infrastructure;
using Infrastructure.Concretes;
using Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebUI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<VisitationDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IVisitService, VisitService>();

            services.AddAutoMapper(typeof(Application.Core.MappingProfiles).Assembly);
            services.AddAutoMapper(typeof(Core.MappingProfiles).Assembly);

            services.AddCookieAuthentication();

            return services;
        }
    }
}