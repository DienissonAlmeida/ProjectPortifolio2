using System;
using ProjectsPortifolio.Application.Features.Projects.Commands;

namespace ProjectsPortifolio.Tests.Common.Features.Projects
{
    public class ProjectRegisterCommandBuilder
    {
        private static ProjectRegisterCommand _command;

        public static ProjectRegisterCommandBuilder Start()
        {
            _command = new ProjectRegisterCommand()
            {
                Name = "Projeto Teste",
                Description = "Reserva de Project",
                InputDate = DateTime.Now,
                OutputDate = DateTime.Now.AddDays(10),
                ManagerId = 1

            };

            return new ProjectRegisterCommandBuilder();
        }


        public ProjectRegisterCommand Build() => _command;

        public ProjectRegisterCommandBuilder WithDescription(string description)
        {
            _command.Description = description;
            return this;
        }

        public ProjectRegisterCommandBuilder WithPerson(PersonCommand personCommand)
        {
            _command.personCommand = personCommand;
            return this;
        }
    }
}
