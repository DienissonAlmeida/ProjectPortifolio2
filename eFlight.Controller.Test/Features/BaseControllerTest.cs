using ProjectsPortifolio.Controller.Test.Features.Flights;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Query.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.UriParser;
using Moq;
using System;
using Xunit;

namespace ProjectsPortifolio.Controller.Test
{
    public class BaseControllerTest : IClassFixture<SetupTest>
    {
        protected ServiceCollection GetServiceCollection()
        {
            var collection = new ServiceCollection();

            collection.AddOData();
            collection.AddODataQueryFilter();
            collection.AddTransient<ODataUriResolver>();
            collection.AddTransient<ODataQueryValidator>();
            collection.AddTransient<TopQueryValidator>();
            collection.AddTransient<FilterQueryValidator>();
            collection.AddTransient<SkipQueryValidator>();
            collection.AddTransient<OrderByQueryValidator>();

            return collection;
        }

        protected ServiceProvider GetServiceProvider()
        {
            return GetServiceCollection().BuildServiceProvider();
        }

        protected ControllerContext GetControllerContext()
        {
            var serviceProvider = GetServiceProvider();

            return new ControllerContext()
            {
                HttpContext = GetHttpContext(serviceProvider)
            };
        }

        protected HttpContext GetHttpContext(ServiceProvider provider)
        {
            return new DefaultHttpContext
            {
                RequestServices = provider
            };
        }

        protected ODataQueryOptions<T> GetOdataQueryOptions<T>(ControllerBase controller, string uriString = "http://localhost:9000/api/any?$top=5") where T : class
        {
            var provider = GetServiceProvider();

            var routeBuilder = new RouteBuilder(Mock.Of<IApplicationBuilder>(x => x.ApplicationServices == provider));
            routeBuilder.EnableDependencyInjection();

            var modelBuilder = new ODataConventionModelBuilder(provider);
            modelBuilder.EntitySet<T>(typeof(T).Name);
            var model = modelBuilder.GetEdmModel();

            var uri = new Uri(uriString);

            var httpContext = GetHttpContext(provider);

            HttpRequest req = new DefaultHttpRequest(httpContext)
            {
                Method = "GET",
                Host = new HostString(uri.Host, uri.Port),
                Path = uri.LocalPath,
                QueryString = new QueryString(uri.Query)
            };

            var context = new ODataQueryContext(model, typeof(T), new Microsoft.AspNet.OData.Routing.ODataPath());
            return new ODataQueryOptions<T>(context, req);
        }

    }
}