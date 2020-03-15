using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsPortifolio.Tests.Common.Extensions
{
    public static class HttpClientExtensions
    {

        public static Task<HttpResponseMessage> DeleteAsync(this HttpClient client, string url, HttpContent content)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Content = content;
            return client.SendAsync(request);
        }

    }
}
