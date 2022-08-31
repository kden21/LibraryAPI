using Contracts.Human.UpdateHuman;
using MediatR;

namespace Handlers.UpdateHuman;

public record UpdateHumanCommand(UpdateHumanRequest Request): IRequest<UpdateHumanResponse>;