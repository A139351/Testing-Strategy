using System.Net;
using AGL.Sample.API.Integration.Tests.Fixtures;
using AGL.Testing.xUnit;
using TestStack.BDDfy;
using Xunit;

namespace AGL.Sample.API.BDD.Tests.Features.Numeric.CalculatorController.Fluent
{
    [Collection(FixtureCollections.OwinServerFixtureCollection)]
    public class AddTests
    {
        private readonly OwinServerFixture _serverFixture;
        private readonly Steps _steps;

        public AddTests(OwinServerFixture serverFixture)
        {
            _serverFixture = serverFixture;
            _steps = new Steps(_serverFixture);
        }


        [Fact]
        public void AddTwoNumbers()
        {
            this.Given(_ => _steps.GivenARequestWithTwoNumbers(13, 14))
                .When(_ => _steps.WhenTheRequestExecutes())
                .Then(_ => _steps.TheResponseCodeIs(HttpStatusCode.OK), "The Response is a success")
                .And(_ => _steps.TheReturnedContentIs(27))
                .BDDfy();
        }
    }
}