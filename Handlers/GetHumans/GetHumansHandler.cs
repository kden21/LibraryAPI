using AppServices.Human.Services;
using Contracts.Human.GetHumans;
using MediatR;

namespace Handlers.GetHumans;

public class GetHumansHandler : IRequestHandler<GetHumansQuery, GetHumansResponse>
{
    private readonly IHumanService _humanService;

    public GetHumansHandler(IHumanService humanService)
    {
        _humanService = humanService;
    }
    public async Task<GetHumansResponse> Handle(GetHumansQuery request, CancellationToken cancellation)
    {
        return await _humanService.GetHumans(request.Request, cancellation);
    }
}