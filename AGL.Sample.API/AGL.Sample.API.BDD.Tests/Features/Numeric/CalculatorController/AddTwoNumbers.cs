using System.Net;
using System.Net.Http;
using AGL.Sample.API.Integration.Tests.Fixtures;
using AGL.Testing.xUnit;
using TestStack.BDDfy;
using Xunit;

namespace AGL.Sample.API.BDD.Tests.Features.Numeric.CalculatorController
{

    [Collection(FixtureCollections.OwinServerFixtureCollection)]
    public class AddTwoNumbers
    {
        private readonly OwinServerFixture _serverFixture;

        private HttpContent _requestContent;
        private HttpResponseMessage _responseMessage;

        public AddTwoNumbers(OwinServerFixture serverFixture)
        {
            _serverFixture = serverFixture;
        }


        public void GivenARequestWithTwoNumbers()
        {
            var request = new[] { 12, 3 };
            _requestContent = _serverFixture.SerialiseBodyContent(request);
        }

        [When("The request is sent to the webserver by the power of http")]
        public async void WhenTheRequestExecutes()
        {
            _responseMessage = await _serverFixture.GetClient<Startup>().PostAsync("api/calculator/add", _requestContent);
        }

        public void ThenTheResponseCodeIs200()
        {
            Assert.Equal(HttpStatusCode.OK, _responseMessage.StatusCode);
        }

        public async void AndThenTheReturnedContentIsTheSumOfTheArguments()
        {
            var parsedResponse = int.Parse(await _responseMessage.Content.ReadAsStringAsync());
            Assert.Equal(15, parsedResponse);
        }



        [Fact]
        public void Execute()
        {
            this.BDDfy();
        }

    }
}