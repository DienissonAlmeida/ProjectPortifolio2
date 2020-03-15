using eFlight.Acceptation.Tests.Components;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Features.Projects.Pages
{
    public class ProjectPage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/Project/div[2]/table/tbody/tr[1]/td[6]/a[3]")]
        public IWebElement ProjectReservationCreateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[2]/div/Project/div[2]/table/tbody/tr[1]/td[6]/a[1]")]
        public IWebElement ProjectReservationViewButton { get; set; }

        [FindsBy(How = How.Id, Using = "customer-list-actions-open")]
        public IWebElement ProjectOpenButton { get; set; }
        #endregion

        public ProjectPage(NgWebDriver ngDriver) : base(ngDriver) { }
    }
}
