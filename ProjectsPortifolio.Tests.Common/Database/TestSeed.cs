using ProjectsPortifolio.Data.Context;
using ProjectsPortifolio.Domain.Features.Projects;
using ProjectsPortifolio.Tests.Common.Features.Projects;

namespace ProjectsPortifolio.Tests.Common.Database
{
    public class TestSeed
    {

        public Project ProjectSeed { get; private set; }

        private ProjectsPortifolioDbContext _context;

        public TestSeed(ProjectsPortifolioDbContext context)
        {
            _context = context;
        }
        public TestSeed()
        {

        }

        public void RunSeed()
        {
            //Apagando e recriando o banco de dados
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            //Salvando os objetos e atribuindo as instâncias as variáveis do seed

            CreateProjectReservation();

            //Confirmando alterações
            _context.SaveChanges();
        }


        private void CreateProjectReservation()
        {
            ProjectSeed = ProjectBuilder.Start().Build();

            ProjectSeed = _context.Project.Add(ProjectSeed).Entity;
        }
    }
}
