
using CampShoping.Application.Servises.Impiementation;
using CampShoping.Application.Servises.Interfaces;
using CampShoping.Data.Repositores;
using CampShoping.Domiain.IRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace CamShoping.IOC
{
    public class DependencyContainer
    {
        public static void CongigureServicCollection(IServiceCollection services)
        {
            //Repository dependency
            services.AddScoped<IUserRepository, UserRepository>();

            // services dependency
            services.AddScoped<IUserService, UserService>();
           
        }
    }
}