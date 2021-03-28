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
    public class CommanderHandlerGetAsync : IRequestHandler<CommanderGetAsync, IEnumerable<Commander>>
    {
        private readonly DatabaseContext _context;
        public CommanderHandlerGetAsync(DatabaseContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Commander>> Handle(CommanderGetAsync request, CancellationToken cancellationToken)
        {
            return await _context
                .Commander
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }
    }
}