using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Domain.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class MakellaarController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllDto>>> GetAllPosts()
        {
            var response = await Mediator.Send(new GetAllQuery());

            return Ok(response);
        }
        
        //[HttpPost]
        //public async Task<ActionResult<CreatePostDto>> CreatePost(CreatePostCommand command)
        //{
        //    var response = await Mediator.Send(command);

        //    return CreatedAtAction(nameof(CreatePost), response);
        //}
    }
}