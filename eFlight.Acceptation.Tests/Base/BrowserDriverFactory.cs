using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eFlight.Acceptation.Tests.Base
{
    public class BrowserDriverFactory
    {
        public IWebDriver CreateDriver(Browser browser, bool headless)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    var optionsChrome = new ChromeOptions();

                    if (headless)
                        optionsChrome.AddArgument("--headless");

                    optionsChrome.AddArguments(
                        "--disable-web-security",
                        "-allow-running-insecure-content",
                        "--disable-gpu",
                        "--window-size=1920x1080",
                        "--no-sandbox");

                    //return new ChromeDriver(Path.GetFullPath("./"), optionsChrome, TimeSpan.FromMinutes(3));
                    return new ChromeDriver(Path.GetFullPath("./"));

                case Browser.Firefox:
                    var optionsFirefox = new FirefoxOptions();

                    if (headless)
                        optionsFirefox.AddArgument("--headless");

                    optionsFirefox.AddArguments(
                        "--disable-web-security",
                        "-allow-running-insecure-content",
                        "--disable-gpu",
                        "--window-size=1920x1080",
                        "--no-sandbox");

                    return new FirefoxDriver(Path.GetFullPath("./"), optionsFirefox, TimeSpan.FromMinutes(3));
            }

            return default(IWebDriver);
        }
    }
}
