using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsPortifolio.Application.Features.Projects.Commands
{
    public class ProjectDeleteCommand : IRequest<bool>
    {
        public int ProjectId { get; set; }
    }
}
