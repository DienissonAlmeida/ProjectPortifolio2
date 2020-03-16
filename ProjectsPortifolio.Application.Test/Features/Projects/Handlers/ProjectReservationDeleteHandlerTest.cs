using ProjectsPortifolio.Application.Features.Projects.Commands;
using ProjectsPortifolio.Application.Features.Projects.Handlers;
using ProjectsPortifolio.Domain.Features.Projects;
using ProjectsPortifolio.Tests.Common.Features.Projects;
using FluentAssertions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ProjectsPortifolio.Application.Test.Features.Cars.Handlers
{
    public class ProjectReservationDeleteHandlerTest : IClassFixture<BaseTest>
    {
        private ProjectDeleteHandler _handler;
        private Mock<IProjectRepository> _fakeRepository;

        public ProjectReservationDeleteHandlerTest()
        {
            _fakeRepository = new Mock<IProjectRepository>();
            _handler = new ProjectDeleteHandler(_fakeRepository.Object);
        }

        [Fact]
        public async Task Deveria_excluir_reserva_de_Project_com_sucesso()
        {

            Project reservation = ProjectBuilder.Start()
                .Build();

            _fakeRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(reservation);

            var cmd = new ProjectDeleteCommand() { ProjectId = 1 };

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeTrue();
            _fakeRepository.Verify(x => x.GetById(cmd.ProjectId), Times.Once);
            _fakeRepository.Verify(x => x.DeleteById(cmd.ProjectId), Times.Once);

        }
    }
}
