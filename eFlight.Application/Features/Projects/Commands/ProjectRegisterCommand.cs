using MediatR;
using System;

namespace ProjectsPortifolio.Application.Features.Projects.Commands
{
    public class ProjectRegisterCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public DateTime InputDate { get; set; }
        public DateTime OutputDate { get; set; }
        public string Description { get; set; }
        public int ManagerId { get; set; }
        public PersonCommand personCommand { get; set; }

    }
}
