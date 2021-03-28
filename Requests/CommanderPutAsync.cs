using System.ComponentModel.DataAnnotations;
using Commanders.Models;
using MediatR;

namespace Commanders.Requests
{
    public class CommanderPutAsync: IRequest<Commander>
    {
        [Required]
        public int Id {get;set;}

        [Required()]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}