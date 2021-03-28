using Commanders.Models;
using MediatR;

namespace Commanders.Requests
{
    public class CommanderGetByIdAsync : IRequest<Commander>
    {
        public int Id { get; set; }
        public CommanderGetByIdAsync(int id)
        {
            Id = id;
        }
    }
}