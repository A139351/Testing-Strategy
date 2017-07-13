using System;
using System.Net.Http;
using System.Text;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;

namespace AGL.Testing.xUnit
{

    public class OwinServerFixture : IDisposable
    {
        private bool _disposed;

        private TestServer _testServer;

        public OwinServerFixture()
        {
            
        }


        public StringContent SerialiseBodyContent<TBodyObject>(TBodyObject content)
        {
            return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }

        public HttpClient GetClient<TStartUp>() => GetServer<TStartUp>().HttpClient;

        public TestServer GetServer<TStartUp>()
        {
            if (_testServer == null)
            {
                _testServer =  TestServer.Create<TStartUp>();
                var uriBuilder = new UriBuilder(_testServer.BaseAddress)
                {
                    Scheme = "https",
                    Port = 443
                };
                _testServer.BaseAddress = uriBuilder.Uri;
            }

            return _testServer;

        }

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

            if (_testServer != null)
            {
                _testServer.Dispose();
                _testServer = null;
            }

            _disposed = true;
        }
    }
}
