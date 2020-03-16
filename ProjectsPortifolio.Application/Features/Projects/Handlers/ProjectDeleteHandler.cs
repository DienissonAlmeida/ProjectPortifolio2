using ProjectsPortifolio.Application.Features.Projects.Commands;
using ProjectsPortifolio.Domain.Features.Projects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectsPortifolio.Application.Features.Projects.Handlers
{
    public class ProjectDeleteHandler : IRequestHandler<ProjectDeleteCommand, bool>
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectDeleteHandler(IProjectRepository projectRepositry)
        {
            _projectRepository = projectRepositry;
        }

        public async Task<bool> Handle(ProjectDeleteCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.ProjectId);

            if (project == null)
                return false;

            if (!project.CanBeDeleted())
                return false;

            await _projectRepository.DeleteById(request.ProjectId);
            return true;
        }
    }
}
