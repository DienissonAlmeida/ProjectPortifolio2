using ProjectsPortifolio.Infra.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectsPortifolio.API.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.ConfigureProfiles(typeof(API.Startup), typeof(Application.AppModule));
        }
    }
}
