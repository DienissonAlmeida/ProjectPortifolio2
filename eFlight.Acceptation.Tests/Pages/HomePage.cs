using eFlight.Acceptation.Tests.Components;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;

namespace eFlight.Acceptation.Tests.Pages
{
    public class HomePage : PageComponents
    {
        #region Selectors
        [FindsBy(How = How.Id, Using = "menu-home")]
        public IWebElement HomeMenu { get; set; }

        [FindsBy(How = How.Id, Using = ".sidebar-wrapper")]
        public IWebElement MainMenu { get; set; }

        [FindsBy(How = How.XPath, Using = ("/html/body/flight-app/div/div[1]/sidebar-cmp/div/ul/li[2]/a"))]
        public IWebElement FlightItem { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[1]/sidebar-cmp/div/ul/li[4]/a/p")]
        public IWebElement CarItem { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/flight-app/div/div[1]/sidebar-cmp/div/ul/li[3]/a/p")]
        public IWebElement ProjectItem { get; set; }

        [FindsBy(How = How.Id, Using = "user-menu-languages-en-us")]
        public IWebElement LanguageEnglishSelect { get; set; }

        [FindsBy(How = How.Id, Using = "user-menu-languages-es-es")]
        public IWebElement LanguageSpanishSelect { get; set; }

        [FindsBy(How = How.Id, Using = "user-menu-languages-pt-br")]
        public IWebElement LanguagePortuguesSelect { get; set; }

        [FindsBy(How = How.Id, Using = "user-menu-selectlang-back")]
        public IWebElement MenuSelectLanguageBack { get; set; }
        #endregion

        public HomePage(NgWebDriver ngDriver) : base(ngDriver) { }

    }
}
