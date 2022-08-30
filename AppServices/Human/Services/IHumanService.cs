using Contracts.Human.CreateHuman;
using Contracts.Human.DeleteHuman;
using Contracts.Human.GetHumanById;
using Contracts.Human.GetHumans;
using Contracts.Human.UpdateHuman;

namespace AppServices.Human.Services;

public interface IHumanService
{
    Task<GetHumansResponse> GetHumans(GetHumansRequest request, CancellationToken cancellation);
    Task<CreateHumanResponse> CreateHuman(CreateHumanRequest request, CancellationToken cancellationToken);
    Task<DeleteHumanResponse> DeleteHuman(DeleteHumanRequest request, CancellationToken cancellationToken);
    Task<UpdateHumanResponse> UpdateHuman(UpdateHumanRequest request, CancellationToken cancellationToken);
    Task<GetHumanByIdResponse> GetHumanById(GetHumanByIdRequest request, CancellationToken cancellation);
}