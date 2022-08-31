using AppServices.Human.Services;
using Contracts.Human.CreateHuman;
using MediatR;

namespace Handlers.CreateHuman;

public record CreateHumanCommand(CreateHumanRequest Request): IRequest<CreateHumanResponse>;