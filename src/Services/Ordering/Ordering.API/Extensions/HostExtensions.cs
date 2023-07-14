using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Ordering.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, 
                                                      Action<TContext, IServiceProvider> seeder, 
                                                      int? retry = 0) 
                                                      where TContext : DbContext
        {
            int retryAvialability = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation($"Migrating database associated with context {typeof(TContext)}");

                    InvokeSeeder(seeder, context, services);

                    logger.LogInformation($"Migrated database associated with context {typeof(TContext)}");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"Error occured while migrationg database associated with context {typeof(TContext)}");
                    
                    if(retryAvialability < 50)
                    {
                        retryAvialability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(host, seeder, retryAvialability);
                    }
                }
            }

            return host;
        }

        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder,
                                                   TContext context,
                                                   IServiceProvider services) 
                                                   where TContext : DbContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }
    }
}
