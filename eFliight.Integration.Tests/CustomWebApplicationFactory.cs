using ProjectsPortifolio.API;
using ProjectsPortifolio.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Xunit;

namespace ProjectsPortifolio.Integration.Tests
{
    [CollectionDefinition("integration collection")]
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>, IDisposable
    {
        public static ProjectsPortifolioDbContext appDb;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

                // Add a database context (AppDbContext) using an in-memory database for testing.
                services.AddDbContext<ProjectsPortifolioDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryAppDb");
                    //options.UseSqlServer("Server=localhost;Database=ProjectsDB;Trusted_Connection=True;MultipleActiveResultSets=true");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                //using (var scope = sp.CreateScope())
                //{
                var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                appDb = scopedServices.GetRequiredService<ProjectsPortifolioDbContext>();

                var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                // Ensure the database is created.
                appDb.Database.EnsureCreated();

                try
                {
                    if (!appDb.Project.Any())
                        SeedData.PopulateTestData(appDb);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the " +
                                        "database with test messages. Error: {ex.Message}");
                }        
            });

        }

        protected override void Dispose(bool disposing)
        {
            if (appDb != null)
            {
                appDb.Dispose();
                base.Dispose(disposing);
            }

        }
    }

    [CollectionDefinition("integration collection")]
    public class DatabaseCollection : ICollectionFixture<CustomWebApplicationFactory<Startup>>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
