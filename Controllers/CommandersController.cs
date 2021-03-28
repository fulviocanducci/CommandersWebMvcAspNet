using Microsoft.AspNetCore.Mvc;
using Commanders.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Commanders.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces("application/json")]
    public class CommandersController: ControllerBase
    {
        public CommandersController()
        {            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async ActionResult<Task<IEnumerable<Commander>>> GetAsync()
        {
            return Ok(null);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async ActionResult<Task<IEnumerable<Commander>>> GetAsync(int id)
        {
            return Ok(null);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async ActionResult<Task<IEnumerable<Commander>>> PostAsync([FromBody])
        {
            return CreatedAtAction("GetAsync", new {id}, new object());
        }
    }
}