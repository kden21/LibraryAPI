using AppServices.Human.Services;
using Contracts.Human.GetHumanById;
using MediatR;

namespace Handlers.GetHumanById;

public class GetHumanByIdHandler : IRequestHandler<GetHumanByIdQuery, GetHumanByIdResponse>
{
    private readonly IHumanService _humanService;

    public GetHumanByIdHandler(IHumanService humanService)
    {
        _humanService = humanService;
    }
    public async Task<GetHumanByIdResponse> Handle(GetHumanByIdQuery request, CancellationToken cancellation)
    {
        return await _humanService.GetHumanById(request.Request, cancellation);
    }
}