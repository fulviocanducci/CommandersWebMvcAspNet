using System.Collections.Generic;
using System.Threading.Tasks;
using Commanders.Models;
using Commanders.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commanders.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    public class TodosController: ControllerBase
    {
        public IMediator Mediator { get; }
        public TodosController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodo()
        {
            return Ok(await Mediator.Send(new TodoGetAsync()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodo(int id)
        {
            var todo = await Mediator.Send(new TodoGetByIdAsync(id));
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult<Commander>> PostTodo(TodoPostAsync model)
        {
            if (ModelState.IsValid)
            {
                var todo = await Mediator.Send(model);
                return CreatedAtAction(nameof(GetTodo), new { todo.Id }, todo);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutTodo(int id, TodoPutAsync model)
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
        public async Task<ActionResult> DeleteTodo(int id)
        {
            var result = await Mediator.Send(new TodoDeleteByIdAsync(id));
            if (result)
            {
                return Ok();
            }
            return NotFound(new { id });
        }
    }
}