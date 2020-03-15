using AutoMapper;
using ProjectsPortifolio.Application.Features.Projects.Commands;
using ProjectsPortifolio.Domain.Features.Projects;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectsPortifolio.Application.Features.Projects.Handlers
{
    public class ProjectUpdateHandler : IRequestHandler<ProjectUpdateCommand, Project>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectUpdateHandler(IProjectRepository ProjectRepository, IMapper mapper)
        {
            _projectRepository = ProjectRepository;
            _mapper = mapper;
        }

        public async Task<Project> Handle(ProjectUpdateCommand request, CancellationToken cancellationToken)
        {
            var productDb = _projectRepository.GetAll().Result.First(x => x.Id == request.Id);

            _mapper.Map(request, productDb);

            await _projectRepository.Update(productDb);

            return productDb;

        }
    }
}
