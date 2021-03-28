using System.ComponentModel.DataAnnotations;
using Commanders.Models;
using MediatR;

namespace Commanders.Requests
{
    public class TodoPostAsync: IRequest<Todo>
    {
        [Required()]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public bool Done {get;set;}
    }
}