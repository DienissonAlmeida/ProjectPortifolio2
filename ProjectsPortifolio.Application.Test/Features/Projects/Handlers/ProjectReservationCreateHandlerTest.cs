using AutoMapper;
using ProjectsPortifolio.Application.Features.Projects.Handlers;
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

namespace ProjectsPortifolio.Application.Test.Features.Projects.Handlers
{
    public class ProjectReservationCreateHandlerTest : IClassFixture<BaseTest>
    {
        private ProjectCreateHandler _handler;
        private Mock<IProjectRepository> _fakeRepository;
        private Mock<IMapper> _fakeMapper;

        public ProjectReservationCreateHandlerTest()
        {
            _fakeRepository = new Mock<IProjectRepository>();
            _fakeMapper = new Mock<IMapper>();
            _handler = new ProjectCreateHandler(_fakeRepository.Object, _fakeMapper.Object);
        }

        [Fact]
        public async Task Deveria_criar_reserva_de_Project_com_sucesso()
        {
            Project reservation = ProjectBuilder.Start().Build();

            var cmd = ProjectRegisterCommandBuilder.Start().Build();
            _fakeMapper.Setup(x => x.Map<Project>(cmd)).Returns(reservation);

            var result = await _handler.Handle(cmd, It.IsAny<CancellationToken>());

            result.Should().BeTrue();
            _fakeRepository.Verify(x => x.Add(It.IsAny<Project>()), Times.Once);
        }
    }
}
