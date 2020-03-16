using MediatR;
using ProjectsPortifolio.Domain.Features.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsPortifolio.Application.Features.Projects.Queries
{
    public class ProjectLoadAllQuery : IRequest<List<Project>>
    {
    }
}
