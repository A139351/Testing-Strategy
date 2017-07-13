using System.Net;
using System.Net.Http;
using AGL.Testing.xUnit;
using TestStack.BDDfy;
using Xunit;

namespace AGL.Sample.API.BDD.Tests.Features.Numeric.CalculatorController.Fluent
{

    
    public class Steps
    {


        private HttpContent _requestContent;
        private HttpResponseMessage _responseMessage;
        private readonly OwinServerFixture _serverFixture;

        public Steps(OwinServerFixture serverFixture)
        {
            _serverFixture = serverFixture;
        }

        public void GivenARequestWithTwoNumbers(int number1, int number2)
        {
            var request = new[] { number1, number2 };
            _requestContent = _serverFixture.SerialiseBodyContent(request);
        }

        public async void WhenTheRequestExecutes()
        {
            _responseMessage = await _serverFixture.GetClient<Startup>().PostAsync("api/calculator/add", _requestContent);
        }

        public void TheResponseCodeIs(HttpStatusCode expectedStatusCode)
        {
            Assert.Equal(expectedStatusCode, _responseMessage.StatusCode);
        }

        public async void TheReturnedContentIs(int expectedResult)
        {
            var parsedResponse = int.Parse(await _responseMessage.Content.ReadAsStringAsync());
            Assert.Equal(expectedResult, parsedResponse);
        }
    }
}