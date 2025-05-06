using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer(StoreDbContext context) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
            try
            {
                // Check if database exist
                if (context.Database.GetPendingMigrations().Any())
                    await context.Database.MigrateAsync();

                if (!context.Orders.Any())
                {
                    var jsonData = await File.ReadAllTextAsync("../Infrastructure/Persistence/Data/Seeding/orders.json");
                    var orders = JsonSerializer.Deserialize<List<Order>>(jsonData);

                    if (orders != null && orders.Any())
                    {
                        await context.Orders.AddRangeAsync(orders);
                        await context.SaveChangesAsync();
                    }
                }

                if (!context.Products.Any())
                {
                    var jsonData = await File.ReadAllTextAsync("../Infrastructure/Persistence/Data/Seeding/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(jsonData);

                    if (products != null && products.Any())
                    {
                        await context.Products.AddRangeAsync(products);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
