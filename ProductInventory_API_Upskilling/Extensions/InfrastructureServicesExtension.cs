namespace ProductInventory_API_Upskilling.Extensions
{
    public static class InfrastructureServicesExtension
    {
        public static IServiceCollection AddInfrastructreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(options =>
                    options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

            return services;
        }
    }
}
