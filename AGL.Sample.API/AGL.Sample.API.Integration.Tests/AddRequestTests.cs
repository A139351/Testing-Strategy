using System.Net;
using System.Threading.Tasks;
using AGL.Sample.API.Integration.Tests.TestHelpers;
using Xunit;

namespace AGL.Sample.API.Integration.Tests
{
    [Collection("OwinServerFixtureCollection")]
    public class AddRequestTests
    {
        private readonly OwinServerFixture _serverFixture;

        public AddRequestTests(OwinServerFixture serverFixture)
        {
            _serverFixture = serverFixture;
        }

        [Fact]
        public async Task Add_WithEmptyListOfIntegers_Returns500()
        {
            var request = new int[0];

            var responseMessage = await _serverFixture.Client.PostAsync("api/calculator/add", _serverFixture.SerialiseBodyContent(request));

            Assert.Equal(HttpStatusCode.InternalServerError, responseMessage.StatusCode);
        }

        [Fact]
        public async Task Add_WithSingleItem_Returns500()
        {
            var request = new[]{1};

            var responseMessage = await _serverFixture.Client.PostAsync("api/calculator/add", _serverFixture.SerialiseBodyContent(request));

            Assert.Equal(HttpStatusCode.InternalServerError, responseMessage.StatusCode);
        }

        [Fact]
        public async Task Add_WithTwoDigitals_ReturnsResultAs200()
        {
            var request = new[] {12, 3};

            var responseMessage = await _serverFixture.Client.PostAsync("api/calculator/add", _serverFixture.SerialiseBodyContent(request));
            var responseBody = int.Parse(await responseMessage.Content.ReadAsStringAsync());

            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
            Assert.Equal(15, responseBody);
        }
    }
}