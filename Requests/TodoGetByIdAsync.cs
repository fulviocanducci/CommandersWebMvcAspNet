using Commanders.Models;
using MediatR;

namespace Commanders.Requests
{
    public class TodoGetByIdAsync : IRequest<Todo>
    {
        public int Id { get; set; }
        public TodoGetByIdAsync(int id)
        {
            Id = id;
        }
    }
}