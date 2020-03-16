using ProjectsPortifolio.Data.Features.Projects;
using ProjectsPortifolio.Domain.Features.Projects;
using Microsoft.EntityFrameworkCore;

namespace ProjectsPortifolio.Data.Context
{
    public class ProjectsPortifolioDbContext : DbContext
    {
        public ProjectsPortifolioDbContext(DbContextOptions<ProjectsPortifolioDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Project { get; set; }

        //public DbSet<Project> ProjectReservation { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());

            CreateRelationships(modelBuilder);

            base.OnModelCreating(modelBuilder);

            if (this.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
                return;

            SeedData(modelBuilder);
        }


        private static void CreateRelationships(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Project>()
            //    .HasMany(x => x.ProjectReservations)
            //    .WithOne(p => p.Project);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration()).Entity<Project>()
            //    .HasData();
          

            base.OnModelCreating(modelBuilder);
        }
    }
}
