using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsPortifolio.Domain.Features.Projects;

namespace ProjectsPortifolio.Infra.Data.Features.Projects
{
    class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Name);
            builder.Property(p => p.Cpf);
            builder.Property(p => p.DateOfBirth);
            builder.Property(p => p.Employee);

        }
    }
}
