namespace ProductInventory_API_Upskilling.Extensions
{
    public static class WebApplicationExtensions
    {
        public async static Task<WebApplication> SeedDbAsync(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbInitualizer = services.GetRequiredService<IDbInitializer>();
            await dbInitualizer.InitializeAsync();

            return app;
        }
    }
}
