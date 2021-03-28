using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Commanders.Requests
{
    public class TodoPutAsync: IRequest<bool>
    {
        [Required]
        public int Id {get;set;}

        [Required()]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public bool Done {get;set;}
    }
}