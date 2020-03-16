using ProjectsPortifolio.API;
using ProjectsPortifolio.Application.Features.Projects.Commands;
using ProjectsPortifolio.Domain.Features.Projects;
using ProjectsPortifolio.Tests.Common.Features.Projects;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;

namespace ProjectsPortifolio.Integration.Tests.Projects
{
    [Collection("integration collection")]
    public class ProjectIntegrationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private const string _url = "api/Projects";

        public ProjectIntegrationTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public void GetProjectReservations_IntegrationTest()
        {
            var httpResponse = _client.GetAsync(_url).Result;

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            var ProjectReservations = JsonConvert.DeserializeObject<List<Project>>(stringResponse);
            var ProjectReservation = ProjectReservations.First();

        }

        [Fact]
        public void GetProject_IntegrationTest()
        {
            var httpResponse = _client.GetAsync(_url).Result;

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            var Projects = JsonConvert.DeserializeObject<List<Project>>(stringResponse);
            var Project = Projects.First();
            Project.Name.Should().Be("Nome Teste");
            Project.Description.Should().Be("cadastro de projeto");


        }

        [Fact]
        public void PostProjectReservation_IntegrationTest()
        {
            //arrange
            var personCommand = new PersonCommand() { Name = "Dienisson" };
            var projectCmd = ProjectRegisterCommandBuilder.Start().WithPerson(personCommand).Build();
            var myContent = JsonConvert.SerializeObject(projectCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            //action
            var httpResponse = _client.PostAsync(_url, stringContent).Result;

            //assert
            httpResponse.EnsureSuccessStatusCode();

            CustomWebApplicationFactory<Startup>.appDb.Project.Count().Should().Be(2);
        }

        [Fact]
        public void DeletProject_IntegrationTest()
        {
            //arrange
            var project = ProjectBuilder.Start().Build();
            CustomWebApplicationFactory<Startup>.appDb.Project.Add(project);
            CustomWebApplicationFactory<Startup>.appDb.SaveChanges();

            var projectCmd = new ProjectDeleteCommand() { ProjectId = project.Id };
            var myContent = JsonConvert.SerializeObject(projectCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            //action
            var httpResponse = ProjectsPortifolio.Tests.Common.Extensions.HttpClientExtensions.DeleteAsync(_client, _url, stringContent).Result;

            httpResponse.EnsureSuccessStatusCode();

            //CustomWebApplicationFactory<Startup>.appDb.Project.Count().Should().Be(1);
        }

        [Fact]
        public void UpdateProject_IntegrationTest()
        {
            var ProjectReservationCmd = new ProjectUpdateCommand()
            {
                Id = 1,
                Description = "Teste atualização",
                PersonId = 1
            };
            var myContent = JsonConvert.SerializeObject(ProjectReservationCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            var httpResponse = _client.PutAsync($"{_url}", stringContent).Result;

            httpResponse.EnsureSuccessStatusCode();

            var projectReservationUpdated = CustomWebApplicationFactory<Startup>.appDb.Project.Find(1);
            //projectReservationUpdated.Description.Should().Be("Teste atualização");
        }
    }
}
