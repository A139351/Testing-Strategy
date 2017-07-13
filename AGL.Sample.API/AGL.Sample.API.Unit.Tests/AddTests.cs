using AGL.Sample.API.Features.Numeric;
using Xunit;

namespace AGL.Sample.API.Unit.Tests
{
    public class AddTests
    {
        [Fact]
        public void Add_WithTwoNumbers_ReturnsTheSum()
        {
            var calculator = new Calculator();

            var result = calculator.Add(12, 5);

            Assert.Equal(17, result);
        }
    }
}