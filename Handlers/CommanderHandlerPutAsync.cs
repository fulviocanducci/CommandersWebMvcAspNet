using System.Threading;
using System.Threading.Tasks;
using Commanders.Datas;
using Commanders.Requests;
using Commanders.Models;
using MediatR;
using System.Linq;

namespace Commanders.Handlers
{
    public class CommanderHandlerPutAsync: IRequestHandler<CommanderPutAsync, bool>
    {
        private readonly DatabaseContext _context;
        public CommanderHandlerPutAsync(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<bool> Handle(CommanderPutAsync request, CancellationToken cancellationToken)
        {
            if (_context.Commander.Any(x => x.Id == request.Id))
            {
                Commander commander = new() { Id = request.Id, Name = request.Name };
                _context.Update(commander);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}