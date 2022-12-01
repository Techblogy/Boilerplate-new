using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Boilerplate.Application.Commands;

public class CreateDummyCommand : IRequest<DummyDto>
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
}