using ProjectsPortifolio.API.Controllers.Features.Projects;
using ProjectsPortifolio.Application.Features.Projects.Commands;
using ProjectsPortifolio.Application.Features.Projects.Queries;
using ProjectsPortifolio.Domain.Features.Projects;
using ProjectsPortifolio.Tests.Common.Features.Projects;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace ProjectsPortifolio.Controller.Test.Features.Projects
{
    public class ProjectReservationControllerTest : BaseControllerTest
    {
        private ProjectsController _controller;
        private Mock<IMediator> _fakeMediator;

        public ProjectReservationControllerTest()
        {
            _fakeMediator = new Mock<IMediator>();
            _controller = new ProjectsController(_fakeMediator.Object);
        }

        [Fact]
        public async void Test_Flight_Controller_GetAsync_ShouldBeOk()
        {
            //arrange
            int expectedCount = 1;
            List<Project> flights = new List<Project>() { new Project() };

            _fakeMediator.Setup(mdtr => mdtr.Send(It.IsAny<ProjectLoadAllQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(flights);

            //action
            var callback = await _controller.Get();

            //assert
            var response = callback.Should().BeOfType<List<Project>>().Subject;
            response.Count.Should().Be(expectedCount);
        }

        [Fact]
        public async void Test_FlightController_PostAsync_ShouldBeOk()
        {
            var registerCommand = ProjectRegisterCommandBuilder.Start().Build();

            _fakeMediator.Setup(mdtr => mdtr.Send(registerCommand, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var callback = await _controller.CreateReservation(registerCommand);

            var response = callback.Should().BeOfType<OkResult>().Subject;
        }

        [Fact]
        public async void Test_FlightController_PutAsync_ShouldBeOk()
        {
            var updateCommand = ProjectUpdateCommandBuilder.Start().WithId(1).Build();

            _fakeMediator.Setup(mdtr => mdtr.Send(updateCommand, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Project());

            var callback = await _controller.Update(updateCommand);


            var response = callback.Should().BeOfType<OkObjectResult>().Subject;

        }

        [Fact]
        public async void Test_FlightController_DeleteAsync_ShouldBeOk()
        {
            var deleteCommand = new ProjectDeleteCommand() { ProjectId = 1 };

            _fakeMediator.Setup(mdtr => mdtr.Send(deleteCommand, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var callback = await _controller.Delete(deleteCommand);


            var response = callback.Should().BeOfType<OkResult>().Subject;
        }
    }
}
