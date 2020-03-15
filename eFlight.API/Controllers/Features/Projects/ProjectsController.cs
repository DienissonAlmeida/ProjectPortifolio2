using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectsPortifolio.Application.Features.Projects.Commands;
using ProjectsPortifolio.Application.Features.Projects.Queries;
using ProjectsPortifolio.Domain.Features.Projects;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectsPortifolio.API.Controllers.Features.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/project
        [HttpGet]
        public Task<List<Project>> Get()
        {
            return _mediator.Send(new ProjectLoadAllQuery());
        }

        [HttpGet]
        [Route("{id:int}")]
        public Task<Project> GetBydId(int id)
        {
            return _mediator.Send(new ProjectReservationLoadByIdQuery() { ProjectReservationId = id });
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] ProjectRegisterCommand projectRegisterCmd)

        {
            await _mediator.Send(projectRegisterCmd);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ProjectDeleteCommand projectDeleteCmd)
        {
            var result = await _mediator.Send(projectDeleteCmd);

            if (result) return Ok(); else return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProjectUpdateCommand projectUpdateCmd)
        {
            var result = await _mediator.Send(projectUpdateCmd);

             return Ok(result);
        }
    }
}