
using ProductInventory_API_Upskilling.Extensions;

namespace ProductInventory_API_Upskilling
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCoreServices()
                            .AddInfrastructreServices(builder.Configuration)
                            .AddPersentationServices();

            var app = builder.Build();


            // Use Static files like images, css, js
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            await app.SeedDbAsync();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
