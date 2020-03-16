using ProjectsPortifolio.Domain.Features.Projects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProjectsPortifolio.Domain.Test
{
    public class ProjectTest
    {

        [Fact]
        public void Nao_deveria_excluir_projeto_com_status_iniciado()
        {
            var project = new Project
            {
                Name = "Projeto",
                StatusProject = StatusProjectEnum.started,
                Person = new Person() { Name = "Dienisson" },
                TotalBudget = 500

            };

            var result = project.CanBeDeleted();

            result.Should().BeFalse();
        }

        [Fact]
        public void Deveria_excluir_projeto_com_status_em_analise()
        {
            var project = new Project
            {
                Name = "Projeto",
                StatusProject = StatusProjectEnum.underAnalysis,
                Person = new Person() { Name = "Dienisson" },
                TotalBudget = 500
            };

            var result = project.CanBeDeleted();

            result.Should().BeTrue();
        }
    }
}
