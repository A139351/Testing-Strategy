using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> Add([FromBody]IEnumerable<int> values)
        {
            var enumerable = values as int[] ?? values.ToArray();
            if (enumerable.Length > 1)
            {
                return Ok(_calculator.Add(enumerable[0], enumerable[1]));
            }
            return InternalServerError(new Exception("No values supplied"));
        }
    }
}