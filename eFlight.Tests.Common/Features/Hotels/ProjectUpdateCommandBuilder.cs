using ProjectsPortifolio.Application.Features.Projects.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsPortifolio.Tests.Common.Features.Projects
{
    public class ProjectUpdateCommandBuilder
    {
        private static ProjectUpdateCommand _command;

        public static ProjectUpdateCommandBuilder Start()
        {
            _command = new ProjectUpdateCommand()
            {
            };

            return new ProjectUpdateCommandBuilder();
        }

        public ProjectUpdateCommand Build() => _command;

        public ProjectUpdateCommandBuilder WithId(int Id)
        {
            _command.Id = Id;
            return this;
        }
    }
}
