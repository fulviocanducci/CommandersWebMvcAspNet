using System.Collections.Generic;
using Commanders.Models;
using MediatR;

namespace Commanders.Requests
{
    public class CommanderGetAsync : IRequest<IEnumerable<Commander>>
    {
    }
}