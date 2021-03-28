using System.Threading;
using System.Threading.Tasks;
using Commanders.Datas;
using Commanders.Requests;
using Commanders.Models;
using MediatR;
using System.Linq;

namespace Commanders.Handlers
{
    public class TodoHandlerPutAsync : IRequestHandler<TodoPutAsync, bool>
    {
        private readonly DatabaseContext _context;
        public TodoHandlerPutAsync(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(TodoPutAsync request, CancellationToken cancellationToken)
        {
            if (_context.Todo.Any(x => x.Id == request.Id))
            {
                Todo todo = new() 
                { 
                    Id = request.Id, 
                    Description = request.Description, 
                    Done = request.Done
                };
                _context.Update(todo);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}