using System.Collections.Generic;
using System.Web.Http;

namespace AGL.Sample.API.Features.Numeric
{
    [RoutePrefix("api/calculator")]
    public class CalculatorController : ApiController
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }


        [Route("add")]
        [HttpPost]
        public IHttpActionResult Add([FromBody]IEnumerable<int> values)
        {
            return Ok("Good Chat!");
        }
    }
}