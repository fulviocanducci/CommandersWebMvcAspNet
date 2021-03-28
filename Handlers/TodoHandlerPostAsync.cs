using System.Threading;
using System.Threading.Tasks;
using Commanders.Datas;
using Commanders.Requests;
using Commanders.Models;
using MediatR;

namespace Commanders.Handlers
{
    public class TodoHandlerPostAsync : IRequestHandler<TodoPostAsync, Todo>
    {
        private readonly DatabaseContext _context;
        public TodoHandlerPostAsync(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Todo> Handle(TodoPostAsync request, CancellationToken cancellationToken)
        {
            Todo todo = new() { Description = request.Description, Done = request.Done};
            await _context.AddAsync(todo);
            await _context.SaveChangesAsync();
            return todo;
        }
    }
}