using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistance
{
    public class SeedDataContext
    {
        public static async Task SeedAsync(ApplicationContext db, ILogger<SeedDataContext> logger)
        {
            if (!db.Orders.Any())
            {
                db.Orders.AddRange(CreateSeedOrders());
                await db.SaveChangesAsync();
                logger.LogInformation($"Seed database associated with context {typeof(ApplicationContext)}");
            }
        }

        private static IEnumerable<Order> CreateSeedOrders()
        {
            return new List<Order>()
            {
                new Order() {UserName = "swn", FirstName = "Mehmet", LastName = "Ozkaya", EmailAddress = "ezozkme@gmail.com", AddressLine = "Bahcelievler", Country = "Turkey", TotalPrice = 350 }
            };
        }
    }
}
