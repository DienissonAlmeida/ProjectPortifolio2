using ProjectsPortifolio.Data.Context;
using ProjectsPortifolio.Tests.Common.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;

namespace ProjectsPortifolio.Infra.Data.Tests.Base
{
    public class DatabaseFixture : IDisposable, IClassFixture<SetupTest>
    {
        public ProjectsPortifolioDbContext Context { get; private set; }
        public TestSeed Seeder { get; set; }

        private IConfigurationRoot _appSettings;
        private string _connectionString;

        public DatabaseFixture()
        {
            _appSettings = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            _connectionString = _appSettings.GetValue<string>("AppSettings:ConnectionString");

            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<ProjectsPortifolioDbContext>()
            .UseInMemoryDatabase(_connectionString)
            .UseInternalServiceProvider(serviceProvider)
            .Options;

            Context = new ProjectsPortifolioDbContext(options);
            Seeder = new TestSeed(Context);

            Seeder.RunSeed();
        }
        public void Dispose()
        {
            DetachAll();
            Context.Dispose();
        }

        public void DetachAll()
        {

            foreach (var dbEntityEntry in this.Context.ChangeTracker.Entries().ToArray())
            {

                if (dbEntityEntry.Entity != null)
                {
                    dbEntityEntry.State = EntityState.Detached;
                }
            }
        }

    }
}
