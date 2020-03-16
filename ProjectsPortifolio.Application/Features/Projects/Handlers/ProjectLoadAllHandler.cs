using ProjectsPortifolio.Application.Features.Projects.Queries;
using ProjectsPortifolio.Domain.Features.Projects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectsPortifolio.Application.Features.Projects.Handlers
{
    public class ProjectLoadAllHandler : IRequestHandler<ProjectLoadAllQuery, List<Project>>
    {
        private readonly IProjectRepository _repository;
        public ProjectLoadAllHandler(IProjectRepository ProjectRepository)
        {
            _repository = ProjectRepository;
        }

        public Task<List<Project>> Handle(ProjectLoadAllQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }

    public class ProjectReservationLoadAByIdHandler : IRequestHandler<ProjectReservationLoadByIdQuery, Project>
    {
        private readonly IProjectRepository _repository;
        public ProjectReservationLoadAByIdHandler(IProjectRepository ProjectRepository)
        {
            _repository = ProjectRepository;
        }


        public Task<Project> Handle(ProjectReservationLoadByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetById(request.ProjectReservationId);
        }
    }
}
