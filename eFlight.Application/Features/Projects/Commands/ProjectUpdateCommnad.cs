using MediatR;
using ProjectsPortifolio.Domain.Features.Projects;
using System;

namespace ProjectsPortifolio.Application.Features.Projects.Commands
{
    public class ProjectUpdateCommand : IRequest<Project>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int PersonId { get; set; }
        public DateTime EndDateForecast { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalBudget { get; set; }
        public string Description { get; set; }
        public StatusProjectEnum StatusProject { get; set; }
        public DegreRiskEnum DegreRisk { get; set; }

    }
}
