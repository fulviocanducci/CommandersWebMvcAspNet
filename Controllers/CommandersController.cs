using Microsoft.AspNetCore.Mvc;
using Commanders.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using MediatR;
using Commanders.Requests;

namespace Commanders.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [Produces("application/json")]
    public class CommandersController : ControllerBase
    {
        public IMediator Mediator { get; }
        public CommandersController(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Commander>>> GetAsync()
        {
            return Ok(await Mediator.Send(new CommanderGetAsync()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Commander>> GetByIdAsync(int id)
        {
            return Ok(await Mediator.Send(new CommanderGetByIdAsync(id)));
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Commander>> PostAsync([FromBody] CommanderPostAsync model)
        {
            if (ModelState.IsValid) 
            {
                var commander = await Mediator.Send(model);
                return CreatedAtAction("GetAsync", new { commander.Id }, commander);
            }
            return BadRequest(ModelState);
        }
    }
}