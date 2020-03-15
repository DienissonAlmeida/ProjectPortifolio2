using ProjectsPortifolio.Domain.Features.Projects;
using MediatR;

namespace ProjectsPortifolio.Application.Features.Projects.Queries
{
    public class ProjectReservationLoadByIdQuery : IRequest<Project>
    {
        public int ProjectReservationId { get; set; }
    }
}
