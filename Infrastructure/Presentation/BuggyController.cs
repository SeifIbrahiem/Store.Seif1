using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        [HttpGet("not found")] //Get : /api/Buggy /notfound
        public IActionResult GetNotFoundRequest()
        {
            //Code
            return NotFound();
        }

        [HttpGet("server error")] //Get : /api/Buggy /servererror
        public IActionResult GetServerErrorRequest()
        {
            throw new Exception();
            return Ok();
        }

        [HttpGet( template:"badrequest")] //Get : /api/Buggy /badrequest
        public IActionResult GetNotBasRequest()
        {
            //Code
            return BadRequest(); //400
        }

        [HttpGet(template: "badrequest / {id}")] //Get : /api/Buggy /badrequest / ahmed
        public IActionResult GetBadRequest(int id)  //validation error
        {
            //Code
            return BadRequest(); //400
        }

        [HttpGet(template: "unauthorized")] //Get : /api/Buggy /unauthorized
        public IActionResult GetUnauthorizedRequest()
        {
            //Code
            return Unauthorized(); //401
        }

    }
}
