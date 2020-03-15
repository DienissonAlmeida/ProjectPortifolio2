using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectsPortifolio.Data.Context;
using ProjectsPortifolio.Domain.Features.Projects;
using Microsoft.EntityFrameworkCore;

namespace ProjectsPortifolio.Infra.Data.Features.Projects
{
    public class ProjectReservationRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectReservationRepository(ProjectsPortifolioDbContext ProjectsPortifolioDbContext) : base(ProjectsPortifolioDbContext)
        {

        }

        //public Task<List<Project>> GetByProjectId(int ProjectId)
        //{
        //    return _context.ProjectReservation.Where(x => x.ProjectId == ProjectId).ToListAsync();
        //}
    }
}
