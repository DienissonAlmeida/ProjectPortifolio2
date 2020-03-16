using ProjectsPortifolio.Data.Context;
using ProjectsPortifolio.Tests.Common.Features.Projects;

namespace ProjectsPortifolio.Integration.Tests
{
    public static class SeedData
    {
        public static void PopulateTestData(ProjectsPortifolioDbContext dbContext)
        {
            dbContext.Project.Add(ProjectBuilder.Start().Build());

            dbContext.SaveChanges();
        }
    }
}