using System.Threading;
using System.Threading.Tasks;
using Commanders.Datas;
using Commanders.Requests;
using Commanders.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commanders.Handlers
{
    public class TodoHandlerGetByIdAsync : IRequestHandler<TodoGetByIdAsync, Todo>
    {
        private readonly DatabaseContext _context;
        public TodoHandlerGetByIdAsync(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Todo> Handle(TodoGetByIdAsync request, CancellationToken cancellationToken)
        {
            return await _context.Todo
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}