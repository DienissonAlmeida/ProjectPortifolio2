using AutoMapper;
using ProjectsPortifolio.Application.Features.Projects.Commands;
using ProjectsPortifolio.Domain.Features.Projects;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace ProjectsPortifolio.Application.Features.Projects.Handlers
{
    public class ProjectCreateHandler : IRequestHandler<ProjectRegisterCommand, bool>
    {
        private readonly IProjectRepository _ProjectReservationRepository;
        private readonly IMapper _mapper;

        public ProjectCreateHandler(IProjectRepository repository, IMapper mapper)
        {
            _ProjectReservationRepository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ProjectRegisterCommand request, CancellationToken cancellationToken)
        {
            var ProjectReservation = _mapper.Map<Project>(request);

            if (request.personCommand != null)
            {
                ProjectReservation.Person = _mapper.Map<Person>(request.personCommand);
                ProjectReservation.Person.SetId();
            }

            if (ProjectReservation.Id == 0)
                ProjectReservation.SetId();
                
            await _ProjectReservationRepository.Add(ProjectReservation);

            return true;
        }
    }
}
