using ProjectsPortifolio.Application.Features.Projects.Handlers;
using ProjectsPortifolio.Application.Features.Projects.Queries;
using ProjectsPortifolio.Domain.Features.Projects;
using ProjectsPortifolio.Tests.Common.Features.Projects;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ProjectsPortifolio.Application.Test.Features.Cars.Handlers
{
    public class ProjectReservationLoadAllHandlerTest : IClassFixture<BaseTest>
    {
        private ProjectLoadAllHandler _handler;
        private Mock<IProjectRepository> _fakeRepository;

        public ProjectReservationLoadAllHandlerTest()
        {
            _fakeRepository = new Mock<IProjectRepository>();
            _handler = new ProjectLoadAllHandler(_fakeRepository.Object);
        }

        [Fact]
        public async Task Deveria_recuperar_reserva_de_Project_com_sucesso()
        {
            List<Project> reservations = new List<Project>()
            {
                ProjectBuilder.Start().Build(),
                ProjectBuilder.Start().Build()
            };

            _fakeRepository.Setup(x => x.GetAll()).ReturnsAsync(reservations);

            var cmd = new ProjectLoadAllQuery();

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeOfType<List<Project>>();
            result.Should().HaveCount(2);
            _fakeRepository.Verify(x => x.GetAll(), Times.Once);

        }
    }
}
