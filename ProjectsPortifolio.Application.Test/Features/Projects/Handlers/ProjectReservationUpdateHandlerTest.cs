using AutoMapper;
using FluentAssertions;
using Moq;
using ProjectsPortifolio.Application.Features.Projects.Handlers;
using ProjectsPortifolio.Domain.Features.Projects;
using ProjectsPortifolio.Tests.Common.Features.Projects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ProjectsPortifolio.Application.Test.Features.Cars.Handlers
{
    public class ProjectReservationUpdateHandlerTest : IClassFixture<BaseTest>
    {
        private ProjectUpdateHandler _handler;
        private Mock<IProjectRepository> _fakeRepository;
        private Mock<IMapper> _mapper;

        public ProjectReservationUpdateHandlerTest()
        {
            _fakeRepository = new Mock<IProjectRepository>();
            _mapper = new Mock<IMapper>();
            _handler = new ProjectUpdateHandler(_fakeRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task Deveria_atualizar_reserva_de_Project_com_sucesso()
        {
            int expected = 1;
            List<Project> reservations = new List<Project>()
            {
                ProjectBuilder.Start().Build(),
                ProjectBuilder.Start().Build()
            };

            _fakeRepository.Setup(x => x.GetAll()).ReturnsAsync(reservations);

            var cmd = ProjectUpdateCommandBuilder.Start().Build();

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().NotBeNull();
            _fakeRepository.Verify(x => x.GetAll(), Times.Once);
            _fakeRepository.Verify(x => x.Update(It.IsAny<Project>()), Times.Once);
        }
    }
}
