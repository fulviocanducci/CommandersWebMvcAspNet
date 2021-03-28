using Commanders.Models;
using MediatR;

namespace Commanders.Requests
{
    public class CommanderDeleteByIdAsync : IRequest<bool>
    {
        public int Id { get; set; }
        public CommanderDeleteByIdAsync(int id)
        {
            Id = id;
        }
    }
}