using ProjectsPortifolio.Domain.Features.Projects;

namespace ProjectsPortifolio.Tests.Common.Features.Projects
{
    public class ProjectBuilder
    {
        private static Project _ProjectReservation;

        private static Person _person;
        public static ProjectBuilder Start()
        {
            _person = new Person() { Id = 1 };

            _ProjectReservation = new Project()
            {
                Name = "Nome Teste",
                Description = "cadastro de projeto",
                Person = _person,
                PersonId = _person.Id,
            };

            return new ProjectBuilder();
        }


        public ProjectBuilder WithPerson(Person person)
        {
            _ProjectReservation.Person = person;
            return this;
        }
        public Project Build() => _ProjectReservation;
    }
}
