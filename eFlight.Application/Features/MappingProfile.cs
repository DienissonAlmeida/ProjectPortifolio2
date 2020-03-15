using AutoMapper;
using ProjectsPortifolio.Application.Features.Projects.Commands;
using ProjectsPortifolio.Domain.Features.Projects;

namespace ProjectsPortifolio.Application.Features.Projects
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProjectRegisterCommand, Project>()
           .ForMember(d => d.Person, opt => opt.MapFrom(s => s.personCommand));
            CreateMap<ProjectUpdateCommand, Project>();
            CreateMap<PersonCommand, Person>();
        }
    }
}
