using System.Threading;
using System.Threading.Tasks;
using Commanders.Datas;
using Commanders.Requests;
using MediatR;

namespace Commanders.Handlers
{
    public class TodoHandlerDeleteByIdAsync : IRequestHandler<TodoDeleteByIdAsync, bool>
    {
        private readonly DatabaseContext _context;
        public TodoHandlerDeleteByIdAsync(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(TodoDeleteByIdAsync request, CancellationToken cancellationToken)
        {
            var model = await _context.Todo.FindAsync(request.Id);
            if (model != null) 
            {
                _context.Todo.Remove(model);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}