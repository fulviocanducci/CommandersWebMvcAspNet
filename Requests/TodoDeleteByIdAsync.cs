using MediatR;

namespace Commanders.Requests
{
    public class TodoDeleteByIdAsync : IRequest<bool>
    {
        public int Id { get; set; }
        public TodoDeleteByIdAsync(int id)
        {
            Id = id;
        }
    }
}