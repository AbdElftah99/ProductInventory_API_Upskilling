using Microsoft.AspNetCore.Mvc;

namespace ProductInventory_API_Upskilling.Extensions
{
    public static class PersentationServiceExtension
    {
        public static IServiceCollection AddPersentationServices(this IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
