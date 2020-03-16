using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectsPortifolio.Domain.Features.Projects;

namespace ProjectsPortifolio.Data.Features.Projects
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Name);
            builder.Property(p => p.EndDate);
            builder.Property(p => p.EndDateForecast);
            builder.Property(p => p.Description);
            builder.Property(p => p.TotalBudget);
            builder.Property(p => p.StartDate);

        }
    }
}
