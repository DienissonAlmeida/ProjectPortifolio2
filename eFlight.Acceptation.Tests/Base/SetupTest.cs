using eFlight.Infra.Settings;
using eFlight.Tests.Common.Settings;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.IO;
using Xunit;

namespace eFlight.Acceptation.Tests.Base
{
    [CollectionDefinition("acceptation collection")]
    public class SetupTest
    {
        internal static AppSettings _appSettings;
        internal static TokenRequest _tokenRequest;
        internal static AcceptanceTestSettings _acceptanceTestSettings;
        protected string _token;

        public SetupTest()
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Path.GetFullPath(@"../../../"))
                                .AddJsonFile("appsettings.json").Build();

            _appSettings = configuration.LoadSettings<AppSettings>("AppSettings");

            _tokenRequest = configuration.LoadSettings<TokenRequest>("TokenRequest");
            _acceptanceTestSettings = configuration.LoadSettings<AcceptanceTestSettings>("AcceptanceTestSettings");
        }

        private string RequestToken()
        {
            var client = new RestClient(_acceptanceTestSettings.AuthEndpoint);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("undefined", $"grant_type={_tokenRequest.GrantType}&username={_tokenRequest.UserName}&client_id={_tokenRequest.ClientId}&password={_tokenRequest.Password}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            JObject jsonResponse = (JObject)JsonConvert.DeserializeObject(response.Content);

            return jsonResponse["AccessToken"].ToString();
        }
    }

    [CollectionDefinition("acceptation collection")]
    public class DatabaseCollection : SetupTest
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}