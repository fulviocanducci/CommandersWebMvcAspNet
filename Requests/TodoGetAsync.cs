using System.Collections.Generic;
using Commanders.Models;
using MediatR;

namespace Commanders.Requests
{
    public class TodoGetAsync : IRequest<IEnumerable<Todo>>
    {
    }
}