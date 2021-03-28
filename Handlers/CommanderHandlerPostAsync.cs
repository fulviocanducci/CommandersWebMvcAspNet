using System.Threading;
using System.Threading.Tasks;
using Commanders.Datas;
using Commanders.Requests;
using Commanders.Models;
using MediatR;

namespace Commanders.Handlers
{
    public class CommanderHandlerPostAsync: IRequestHandler<CommanderPostAsync, Commander>
    {
        private readonly DatabaseContext _context;
        public CommanderHandlerPostAsync(DatabaseContext context)
        {
            _context = context;

        }
        
        public async Task<Commander> Handle(CommanderPostAsync request, CancellationToken cancellationToken)
        {
            Commander commander = new Commander { Name = request.Name};
            await _context.AddAsync(commander);
            await _context.SaveChangesAsync();
            return commander;
        }
    }
}