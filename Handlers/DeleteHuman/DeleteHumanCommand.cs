using Contracts.Human.DeleteHuman;
using MediatR;

namespace Handlers.DeleteHuman;

public record DeleteHumanCommand(DeleteHumanRequest Request): IRequest<DeleteHumanResponse>;