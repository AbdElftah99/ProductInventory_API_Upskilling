using Services;
using Services.Abstraction;

namespace ProductInventory_API_Upskilling.Extensions
{
    public static class CoreServicesExtension
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddAutoMapper(typeof(ServicesAssembly).Assembly);

            return services;
        }
    }
}
