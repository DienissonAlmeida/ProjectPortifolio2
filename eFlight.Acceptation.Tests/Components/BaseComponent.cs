using Protractor;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Components
{
    public class BaseComponent
    {
        public NgWebDriver NgDriver { get; private set; }

        public BaseComponent(NgWebDriver ngDriver)
        {
            NgDriver = ngDriver;
            PageFactory.InitElements(ngDriver, this);
        }

    }
}
