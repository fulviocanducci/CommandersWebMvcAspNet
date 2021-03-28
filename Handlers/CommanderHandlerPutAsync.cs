using System.Threading;
using System.Threading.Tasks;
using Commanders.Datas;
using Commanders.Requests;
using Commanders.Models;
using MediatR;

namespace Commanders.Handlers
{
    public class CommanderHandlerPutAsync: IRequestHandler<CommanderPutAsync, Commander>
    {
        private readonly DatabaseContext _context;
        public CommanderHandlerPutAsync(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<Commander> Handle(CommanderPutAsync request, CancellationToken cancellationToken)
        {
            Commander commander = new Commander { Id = request.Id, Name = request.Name};
            _context.Update(commander);
            await _context.SaveChangesAsync();
            return commander;
        }
    }
}