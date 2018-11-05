using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SWTP.Application.Interfaces;
using SWTP.Application.Services;
using SWTP.Domain.Interfaces.Repository;
using SWTP.Domain.Interfaces.Services;
using SWTP.Domain.Services;
using SWTP.Infra.Context;
using SWTP.Infra.Repository;

namespace SWTP.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Application
            services.AddScoped<IStarShipApplication, StarShipApplication>();

            //Domain
            services.AddScoped<IStarShipDomain, StarShipDomain>();

            //Repository
            services.AddScoped<IStarShipRepository, StarShipRepository>();

            services.AddScoped<SwtpContext>();
        }
    }
}
