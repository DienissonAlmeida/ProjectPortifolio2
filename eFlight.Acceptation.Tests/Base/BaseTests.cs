using eFlight.Acceptation.Tests.Extensions;
using eFlight.Data.Context;
using eFlight.Infra.Settings;
using eFlight.Tests.Common.Database;
using eFlight.Tests.Common.Settings;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using Protractor;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace eFlight.Acceptation.Tests.Base
{
    public abstract class BaseTests : IClassFixture<SetupTest>, IDisposable
    {
        public NgWebDriver NgDriver { get; private set; }

        private IWebDriver _driver;
        private Browser _browser;
        private bool _headless;
        private BrowserDriverFactory _driverFactory;

        protected string _token;

        protected eFlightDbContext _context;
        protected TestSeed _seeder;

        public BaseTests(Browser browser = Browser.Chrome, bool headless = false)
        {
            _browser = browser;
            _headless = headless;

            _driverFactory = new BrowserDriverFactory();

            ResetDatabase();

            _driver = _driverFactory.CreateDriver(_browser, _headless);

            _driver.Manage().Window.Maximize();
            _driver.Url = SetupTest._acceptanceTestSettings.BaseClientUrl;

            // Timeouts
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            _driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(80);

            NgDriver = new NgWebDriver(_driver);

        }

        private void ResetDatabase()
        {
            var options = new DbContextOptionsBuilder<eFlightDbContext>().UseSqlServer(SetupTest._appSettings.ConnectionString).Options;
            _context = new eFlightDbContext(options);
            _seeder = new TestSeed(_context);
            _seeder.RunSeed();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();

            NgDriver.Quit();
            NgDriver.Dispose();
        }
    }
}
