using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IMSApi.Models;
using IMSApi.Data;

namespace IMSApi.Seeder
{
    public static class DataSeeder
    {

        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDBContext>();

                // Apply pending migrations (if any)
                context.Database.Migrate();  

                // Seed data
                SeedStaff(context);
            }
        }

        private static void SeedStaff(AppDBContext context)
        {
            var password = BCrypt.Net.BCrypt.HashPassword("admin1234");
            if (!context.Staff.Any())
            {
                context.Staff.AddRange(
                    new Staff { Name = "Admin User", Email = "admin@example.com", Password = password, Role = "Admin", Phone = "1234567890" }
                   
                );
                context.SaveChanges();
            }
        }

    }
}
