using eFlight.Acceptation.Tests.Components;
using eFlight.Application.Features.Projects.Commands;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;

namespace eFlight.Acceptation.Tests.Features.Projects.Pages
{
    public class ProjectReservationFormPage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/Project-reservation-form/div/div[2]/form/div[1]/input")]
        public IWebElement ProjectReservationDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/Project-reservation-form/div/div[2]/form/div[2]/input")]
        public IWebElement ProjectReservationDate { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/Project-reservation-form/div/div[2]/form/div[3]/input")]
        public IWebElement ProjectReservationReturn { get; set; }
        #endregion

        public ProjectReservationFormPage(NgWebDriver ngDriver) : base(ngDriver) { }

        public void FillData(ProjectReservationRegisterCommand command)
        {
            ProjectReservationDescription.SendKeys(command.Description);
            ProjectReservationDate.SendKeys(command.InputDate.GetDateTimeFormats()[50]);
            ProjectReservationReturn.SendKeys(command.OutputDate.GetDateTimeFormats()[50]);
        }
        public void ClearData()
        {
            ProjectReservationDescription.Clear();
            ProjectReservationDate.Clear();
            ProjectReservationReturn.Clear();
        }
    }
}
