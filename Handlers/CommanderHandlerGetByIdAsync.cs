using System.Threading;
using System.Threading.Tasks;
using Commanders.Datas;
using Commanders.Requests;
using Commanders.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commanders.Handlers
{
    public class CommanderHandlerGetByIdAsync : IRequestHandler<CommanderGetByIdAsync, Commander>
    {
        private readonly DatabaseContext _context;
        public CommanderHandlerGetByIdAsync(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Commander> Handle(CommanderGetByIdAsync request, CancellationToken cancellationToken)
        {
            return await _context.Commander
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}