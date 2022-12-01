using Boilerplate.Application.Queries;
using MediatR;

namespace Boilerplate.Api.Controllers;


[Authorize(Policy = nameof(AuthorizationRequirement))]
[Route("api/dummynew")]
[ApiController]
public class DummyNewController: Controller
{
    
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public DummyNewController(ISender mediator, IMapper mapper)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetDummyResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<GetDummyResponse>))]
    [HttpGet]
    public async Task<ActionResult<List<GetDummyResponse>>> GetAsync()
    {
        var result = await _mediator.Send(new GetAllDummiesQuery());
        return Ok(_mapper.Map<List<GetDummyResponse>>(result));
    }
    
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDummyResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GetDummyResponse))]
    [HttpGet("{id}")]
    public async Task<ActionResult<GetDummyResponse>> GetAsync(int id)
    {
        var result = await _mediator.Send(new GetDummyQuery(id));
        return Ok(_mapper.Map<GetDummyResponse>(result));
    }
}