using System.Threading;
using System.Threading.Tasks;
using Commanders.Datas;
using Commanders.Requests;
using MediatR;

namespace Commanders.Handlers
{
    public class CommanderHandlerDeleteByIdAsync : IRequestHandler<CommanderDeleteByIdAsync, bool>
    {
        private readonly DatabaseContext _context;
        public CommanderHandlerDeleteByIdAsync(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CommanderDeleteByIdAsync request, CancellationToken cancellationToken)
        {
            var model = await _context.Commander.FindAsync(request.Id);
            if (model != null) 
            {
                _context.Commander.Remove(model);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}