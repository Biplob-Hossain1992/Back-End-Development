using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserInformation.Application.IRepositories;
using UserInformation.Infrastructure.Repositories;

namespace UserInformation.Infrastructure.Service
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            return services;
        }
    }
}
