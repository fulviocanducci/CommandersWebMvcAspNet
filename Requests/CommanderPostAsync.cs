using Commanders.Models;
using MediatR;

namespace Commanders.Requests
{
    public class CommanderPostAsync: IRequest<Commander>
    {
        public string Name { get; set; }
    }
}