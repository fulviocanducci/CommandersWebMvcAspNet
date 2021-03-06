using Commanders.Models;
using Commanders.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commanders.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    public class CommandersController : ControllerBase
    {
        public IMediator Mediator { get; }
        public CommandersController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Commander>>> GetCommander()
        {
            return Ok(await Mediator.Send(new CommanderGetAsync()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Commander>> GetCommander(int id)
        {
            var commander = await Mediator.Send(new CommanderGetByIdAsync(id));
            if (commander == null)
            {
                return NotFound();
            }
            return Ok(commander);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult<Commander>> PostCommander(CommanderPostAsync model)
        {
            if (ModelState.IsValid)
            {
                var commander = await Mediator.Send(model);
                return CreatedAtAction(nameof(GetCommander), new { commander.Id }, commander);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutCommander(int id, CommanderPutAsync model)
        {
            if (id != model.Id)
            {
                return BadRequest(new { Error = "Different Id from Model.Id" });
            }
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(model);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(model);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCommander(int id)
        {
            var result = await Mediator.Send(new CommanderDeleteByIdAsync(id));
            if (result)
            {
                return Ok();
            }
            return NotFound(new { id });
        }
    }
}