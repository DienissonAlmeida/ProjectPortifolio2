using ProjectsPortifolio.Domain.Features.Projects;
using ProjectsPortifolio.Infra.Data.Features.Projects;
using ProjectsPortifolio.Infra.Data.Tests.Base;
using ProjectsPortifolio.Tests.Common.Features.Projects;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace ProjectsPortifolio.Infra.Data.Tests.Projects
{
    [Collection("Database collection")]
    public class ProjectReservationRepositoryTest : DatabaseFixture
    {
        //DatabaseFixture databaseFixture;

        private ProjectReservationRepository _repository;

        public ProjectReservationRepositoryTest()
        {
            _repository = new ProjectReservationRepository(Context);
            //databaseFixture = fixture;
        }

        [Fact]
        public void Deveria_adicioanar_uma_reserva_de_Project_no_contexto()
        {
            //Arrange
            Project ProjectReservation = ProjectBuilder.Start().Build();

            ProjectReservation.SetId();

            //Action
            var ProjectReservationAdd = _repository.Add(ProjectReservation);

            //Assert
            var expectedProjectReservation = Context.Project.Find(ProjectReservationAdd.Result.Id);
            expectedProjectReservation.Should().NotBeNull();
        }

        //#region GET

        [Fact]
        public void Deveria_retornar_todos_as_reservas_de_hoteis_do_contexto()
        {
            //Action
            var ProjectsReservations = _repository.GetAll().Result.ToList();

            //Assert
            ProjectsReservations.Should().HaveCount(1);
        }

        //TODO: Analisar uma forma de retornar somente a entidade e não as dependencias
        [Fact]
        public void Deveria_retornar_a_reseeva_de_Project_pelo_id()
        {
            //Action
            var ProjectReservationDb = _repository.GetById(Seeder.ProjectSeed.Id);

            //Assert
            ProjectReservationDb.Id.Should().Equals(Seeder.ProjectSeed.Id);
        }


        [Fact]
        public void Deveria_retornar_reserva_de_Project_por_id_e_suas_dependencias()
        {
            //Action
            var ProjectReservationDb = _repository.GetById(Seeder.ProjectSeed.Id);

            //Assert
            ProjectReservationDb.Id.Should().Equals(Seeder.ProjectSeed.Id);
        }

        //#endregion GET

        [Fact]
        public void Deveria_excluir_reserva_de_voo_do_contexto()
        {
            //Action
            //var callbackRemove = _repository.DeleteById(Seeder.FlightReservationSeedOne.Id);

            //Assert

            var ProjectReservations = _repository.GetAll();

            ProjectReservations.Result.Should().HaveCount(1);
        }

        [Fact]
        public void Deveria_atualizar_reserva_de_Project_no_contexto()
        {
            //Arrange


            //Action
            _repository.Update(Seeder.ProjectSeed);

            //Assert
            var expectedProjectReservation = Context.Project.Find(Seeder.ProjectSeed.Id);
        }
    }
}
