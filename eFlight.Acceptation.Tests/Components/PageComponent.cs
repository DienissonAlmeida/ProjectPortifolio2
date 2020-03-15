using Protractor;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Components
{
    public class PageComponents : BaseComponent
    {
        public GenericGridComponent GenericGridComponent { get; set; }
        public DefaultButtonsComponent DefaultButtonsComponent { get; set; }
        //public DialogComponent DialogComponent { get; set; }

        public PageComponents(NgWebDriver ngDriver) : base(ngDriver)
        {
            GenericGridComponent = new GenericGridComponent(ngDriver);
            DefaultButtonsComponent = new DefaultButtonsComponent(ngDriver);
            //DialogComponent = new DialogComponent(NgDriver);
        }
    }
}
