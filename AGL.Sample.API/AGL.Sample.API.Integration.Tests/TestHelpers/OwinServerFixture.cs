using System;
using System.Net.Http;
using System.Text;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using Xunit;

namespace AGL.Sample.API.Integration.Tests.TestHelpers
{

    [CollectionDefinition("OwinServerFixtureCollection")]
    public class TestServerFixtureCollection : ICollectionFixture<OwinServerFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    public class OwinServerFixture : IDisposable
    {
        private bool _disposed;

        public OwinServerFixture()
        {


            Server = TestServer.Create<Startup>();
            var uriBuilder = new UriBuilder(Server.BaseAddress)
            {
                Scheme = "https",
                Port = 443
            };
            Server.BaseAddress = uriBuilder.Uri;
        }


        internal StringContent SerialiseBodyContent<TBodyObject>(TBodyObject content)
        {
            return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }

        internal HttpClient Client => Server.HttpClient;
        internal TestServer Server { get; private set; }

        ~OwinServerFixture()
        {
            Dispose(false);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _disposed) { return; }

            if (Server != null)
            {
                Server.Dispose();
                Server = null;
            }

            _disposed = true;
        }
    }
}
