using Contracts.Human.Dto;

namespace Contracts.Human.GetHumans;

public record GetHumansResponse
{
    public IEnumerable<HumanDto> Humans { get; set; } = null!;
}