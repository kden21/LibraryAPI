using System.Net;
using Contracts.Human.CreateHuman;
using Contracts.Human.DeleteHuman;
using Contracts.Human.GetHumanById;
using Contracts.Human.GetHumans;
using Contracts.Human.UpdateHuman;
using Handlers.CreateHuman;
using Handlers.DeleteHuman;
using Handlers.GetHumanById;
using Handlers.GetHumans;
using Handlers.UpdateHuman;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[Route("api/humans")]
[Produces("application/json")]
[ApiController]
public class HumansController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public HumansController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("getHumans")]
    [ProducesResponseType(typeof(GetHumansResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetHumans([FromQuery] GetHumansRequest request, CancellationToken cancellation)
    {
        return Ok(await _mediator.Send(new GetHumansQuery(request), cancellation));
    }
    
    [HttpPost("createHuman")]
    [ProducesResponseType(typeof(CreateHumanResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateHuman([FromBody] CreateHumanRequest request, CancellationToken cancellation)
    {
        return Ok(await _mediator.Send(new CreateHumanCommand(request), cancellation));
    }
    
    [HttpPost("deleteHuman")]
    [ProducesResponseType(typeof(DeleteHumanResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteHuman([FromQuery] DeleteHumanRequest request, CancellationToken cancellation)
    {
        return Ok(await _mediator.Send(new DeleteHumanCommand(request), cancellation));
    }
    
    [HttpPost("updateHuman")]
    [ProducesResponseType(typeof(UpdateHumanResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateHuman([FromBody] UpdateHumanRequest request, CancellationToken cancellation)
    {
        return Ok(await _mediator.Send(new UpdateHumanCommand(request), cancellation));
    }
    
    [HttpGet("getHumanById")]
    [ProducesResponseType(typeof(GetHumanByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetHumanById([FromQuery] GetHumanByIdRequest request, CancellationToken cancellation)
    {
        return Ok(await _mediator.Send(new GetHumanByIdQuery(request), cancellation));
    }
}