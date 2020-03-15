using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Acceptation.Tests.Extensions
{
    public static class WebDriverExtensions
    {
        public static void SetLocalStorage(this IWebDriver driver, string token, string authEndpoint)
        {
            var jsEngine = driver as IJavaScriptExecutor;

            var localStorageTokenKey = $"window.localStorage.setItem('NDDResearchToken', '{ token }')";
            jsEngine.ExecuteScript(localStorageTokenKey);

            var user = "{ \"UserId\":\"1\", \"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress\":\"admin@admin.com\", " +
                "\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name\":\"Admin\", \"aud\":\"3b9a77fb35a54e40815f4fa8641234c5\", \"nbf\":1545325828, " +
                "\"exp\":1545329428, \"iss\":\"" + authEndpoint + "\" }";

            var localStorageUserKey = $"window.localStorage.setItem('NDDResearchUser', { JsonConvert.SerializeObject(user).ToString() })";
            jsEngine.ExecuteScript(localStorageUserKey);

            var dealerSettings = "{}";
            var localStorageDealerSettingsKey = $"window.localStorage.setItem('NDDResearchDealerSettings', { JsonConvert.SerializeObject(dealerSettings).ToString() })";
            jsEngine.ExecuteScript(localStorageDealerSettingsKey);

            var localStorageCurrentLangKey = "window.localStorage.setItem('NDDResearchCurrentLang', 'pt-br')";
            jsEngine.ExecuteScript(localStorageCurrentLangKey);
        }

    }
}
