using eFlight.Acceptation.Tests.Base;
using eFlight.Acceptation.Tests.Features.Projects.Pages;
using eFlight.Acceptation.Tests.Pages;
using eFlight.Tests.Common.Features.Projects;
using FluentAssertions;
using System.Threading;
using Xunit;

namespace eFlight.Acceptation.Tests.Features.Projects
{
    [Collection("acceptation collection")]
    public class ProjectReservationAcceptationCreateTest : BaseTests
    {
        private ProjectPage _ProjectPage;
        private ProjectReservationPage _ProjectReservationPage;
        private ProjectReservationFormPage _ProjectReservationFormPage;

        public ProjectReservationAcceptationCreateTest()
        {
            string urlToGo = SetupTest._acceptanceTestSettings.BaseClientUrl + "home";

            var homePage = new HomePage(NgDriver);
            //var subMenusPage = new CustomerSubMenuComponent(NgDriver);

            _ProjectPage = new ProjectPage(NgDriver);
            //_flightReservationPage = new FlightReservationPage(NgDriver);
            _ProjectReservationFormPage = new ProjectReservationFormPage(NgDriver);

            //NgDriver.Navigate().GoToUrl(urlToGo);

            //homePage.MainMenu.WaitUntilBeVisibleAndClickOnIt(NgDriver);

            homePage.ProjectItem.Click();
            //subMenusPage.CustomersSubMenu.Click();

        }

        [Fact]
        public void Deveria_Salvar_Reserva_Project_com_sucesso()
        {
            //Arrange
            _ProjectPage.ProjectReservationCreateButton.Click();

            var command = ProjectReservationRegisterCommandBuilder.Start().Build();
            _ProjectReservationFormPage.FillData(command);

            //act
            _ProjectReservationFormPage.DefaultButtonsComponent.SaveButton.Click();
            Thread.Sleep(1000);
            NgDriver.SwitchTo().Alert().Accept();

            //assert
            NgDriver.Url.Should().Contain("/Projects");
            //_flightReservationPage.GenericGridComponent.HasAnyRow(2, command.Description).Should().BeTrue();
        }

        [Fact]
        public void Deveria_editar_Reserva_Project_com_sucesso()
        {
            _ProjectPage.ProjectReservationViewButton.Click();
            _ProjectReservationPage = new ProjectReservationPage(NgDriver);

            //action
            _ProjectReservationPage.ProjectReservationOpenButton.Click();
            _ProjectReservationFormPage.ClearData();
            var command = ProjectReservationRegisterCommandBuilder.Start().WithDescription("Atualizacao de reserva de voo").Build();
            _ProjectReservationFormPage.FillData(command);
            _ProjectReservationFormPage.DefaultButtonsComponent.SaveButton.Click();
            Thread.Sleep(1000);
            NgDriver.SwitchTo().Alert().Accept();

            //assert
            NgDriver.Url.Should().Contain("/Projects");
        }

        [Fact]
        public void Deveria_deletar_Reserva_Project_com_sucesso()
        {
            _ProjectPage.ProjectReservationViewButton.Click();
            _ProjectReservationPage = new ProjectReservationPage(NgDriver);

            //action
            _ProjectReservationPage.ProjectDeleteButton.Click();
            Thread.Sleep(1000);
            NgDriver.SwitchTo().Alert().Accept();

            //assert
            NgDriver.Url.Should().Contain("/ProjectReservation");
        }
    }
}
