using System.ComponentModel.DataAnnotations;
using Commanders.Models;
using MediatR;

namespace Commanders.Requests
{
    public class CommanderPostAsync: IRequest<Commander>
    {
        [Required()]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}