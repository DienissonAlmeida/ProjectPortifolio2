using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsPortifolio.Domain.Features.Projects
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public DateTime EndDateForecast { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalBudget { get; set; }
        public string Description { get; set; }
        public StatusProjectEnum StatusProject { get; set; }
        public DegreRiskEnum DegreRisk { get; set; }

        public bool CanBeDeleted()
        {
            return StatusProject != StatusProjectEnum.started && StatusProject != StatusProjectEnum.planned
                && StatusProject != StatusProjectEnum.inProgress && StatusProject != StatusProjectEnum.closed
                && StatusProject != StatusProjectEnum.canceled;
        }
    }
}
