using System.Collections;
using System.Collections.Generic;
using System.Web.Http;

namespace AGL.Sample.API.Features.Numeric
{
    [Route("api/calculator")]
    public class CalculatorController : ApiController
    {



        [Route("Add")]
        public void Add([FromBody]IEnumerable<int> values)
        {

        }
    }
}