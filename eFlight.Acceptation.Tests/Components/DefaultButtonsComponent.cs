using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Components
{
    public class DefaultButtonsComponent : BaseComponent
    {
        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Salvar')]")]
        public IWebElement SaveButton { get; set; }
        public DefaultButtonsComponent(NgWebDriver ngDriver) : base(ngDriver) { }
    }
}
