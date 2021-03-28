using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Commanders.Datas;
using Commanders.Requests;
using Commanders.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commanders.Handlers
{
    public class TodoHandlerGetAsync: IRequestHandler<TodoGetAsync, IEnumerable<Todo>>
    {
        private readonly DatabaseContext _context;
        public TodoHandlerGetAsync(DatabaseContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Todo>> Handle(TodoGetAsync request, CancellationToken cancellationToken)
        {
            return await _context
                .Todo
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }
    }
}