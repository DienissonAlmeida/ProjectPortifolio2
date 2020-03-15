using eFlight.Acceptation.Tests.Components;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;

namespace eFlight.Acceptation.Tests.Features.Projects.Pages
{
    public class ProjectReservationPage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/flight/div[2]/table/tbody/tr[1]/td[5]/a[3]")]
        public IWebElement ProjectReservationCreateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/app-Project-reservation/div[2]/table/tbody/tr/td[5]/a[3]")]
        public IWebElement ProjectDeleteButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/app-Project-reservation/div[2]/table/tbody/tr/td[5]/a[1]")]
        public IWebElement ProjectReservationOpenButton { get; set; }
        #endregion

        public ProjectReservationPage(NgWebDriver ngDriver) : base(ngDriver) { }
    }
}
