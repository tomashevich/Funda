using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class MakellaarController : BaseController
    {
        [HttpGet]
        [Route("top")]
        public async Task<ActionResult<IEnumerable<GetAllDto>>> GetAll()
        {
            var response = await Mediator.Send(new GetAllQuery());

            return Ok(response);
        }

        [HttpGet]
        [Route("top/tuin")]
        public async Task<ActionResult<IEnumerable<GetAllDto>>> GetAllWithTuin()
        {
            var response = await Mediator.Send(new GetAllWithTuinQuery());

            return Ok(response);
        }
    }
}