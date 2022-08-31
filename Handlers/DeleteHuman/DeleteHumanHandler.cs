using AppServices.Human.Services;
using Contracts.Human.DeleteHuman;
using MediatR;

namespace Handlers.DeleteHuman;

public class DeleteHumanHandler: IRequestHandler<DeleteHumanCommand, DeleteHumanResponse>
{
    private readonly IHumanService _humanService;

    public DeleteHumanHandler(IHumanService humanService)
    {
        _humanService = humanService;
    }
    public async Task<DeleteHumanResponse> Handle(DeleteHumanCommand request, CancellationToken cancellation)
    {
        return await _humanService.DeleteHuman(request.Request, cancellation);
    }
}