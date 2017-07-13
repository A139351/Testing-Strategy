using AGL.Testing.xUnit;
using Xunit;

namespace AGL.Sample.API.Integration.Tests.Fixtures
{
    public struct FixtureCollections
    {
        public const string OwinServerFixtureCollection = "OwinServerFixtureCollection";
    }

    [CollectionDefinition(FixtureCollections.OwinServerFixtureCollection)]
    public class TestServerFixtureCollection : ICollectionFixture<OwinServerFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}