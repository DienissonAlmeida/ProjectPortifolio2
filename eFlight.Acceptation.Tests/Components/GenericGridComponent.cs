using eFlight.Acceptation.Tests.Extensions;
using OpenQA.Selenium;
using Protractor;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eFlight.Acceptation.Tests.Components
{
    public class GenericGridComponent : BaseComponent
    {
        #region Selectors
        [FindsBy(How = How.CssSelector, Using = (".ndd-ng-grid-filter__input"))]
        public IWebElement SearchInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = (".ndd-ng-filter-simple__input"))]
        public IWebElement SearchSimpleInput { get; set; }
        #endregion

        public GenericGridComponent(NgWebDriver ngDriver) : base(ngDriver) { }

        public bool HasAnyRow(int columnIndex, string textToSearch)
        {
            var columnsElements = NgDriver.AvoidStaleElements(By.XPath(string.Format("//tbody//*/td[{0}]", columnIndex)));

            return columnsElements.Any(c => c.Text.ToLowerInvariant().Equals(textToSearch.ToLowerInvariant()));
        }
    }
}
