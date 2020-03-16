using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectsPortifolio.Application.Features.Projects.Commands;
using ProjectsPortifolio.Domain.Features.Projects;
using ProjectsPortifolio.Tests.Common.Features.Projects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsPortifolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly HttpClient client;

        public TestController()
        {
            client = new HttpClient();
        }

        [HttpGet]
        [Route("post/{seat:int}")]
        public async Task<IActionResult> Postproduct(int seat)
        {
            var person = new PersonCommand() { Name = "Paulo" };
            var productCmd = ProjectRegisterCommandBuilder.Start().WithPerson(person).Build();

            var myContent = JsonConvert.SerializeObject(productCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            var result = await client.PostAsync("https://localhost:44301/api/projects", stringContent);

            return Ok();
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeletProjectsPortifolio(int id)
        {
            var productCmd = new ProjectDeleteCommand()
            {
                ProjectId = id

            };

            var myContent = JsonConvert.SerializeObject(productCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            await Tests.Common.Extensions.HttpClientExtensions.DeleteAsync(client, "https://localhost:44301/api/projects", stringContent);

            return Ok();
        }

        [HttpGet]
        [Route("update/{id:int}")]
        public async Task<IActionResult> UpdatProjectsPortifolio(int id)

        {
            var productCmd = new ProjectUpdateCommand()
            {
                Id = id,
                Description = "descriptionnnn",
                Name = "Nameee",
                PersonId = 1101109046
                //productCustomers = new List<CustomerUpdateCommand>() { new CustomerUpdateCommand() { Name = "Roberto", LastName = "Bola", Sex = SexEnum.Male } }
            };

            var myContent = JsonConvert.SerializeObject(productCmd);
            var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");

            var result = await client.PutAsync($"https://localhost:44301/api/projects", stringContent);

            return Ok();
        }

    }

}
