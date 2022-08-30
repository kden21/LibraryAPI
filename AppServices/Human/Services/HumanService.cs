using AppServices.Shared;
using AutoMapper;
using Contracts.Human.CreateHuman;
using Contracts.Human.DeleteHuman;
using Contracts.Human.Dto;
using Contracts.Human.GetHumanById;
using Contracts.Human.GetHumans;
using Contracts.Human.UpdateHuman;
using Domain;
using Microsoft.Extensions.Configuration;

namespace AppServices.Human.Services;

public class HumanService
{
    private readonly IHumanRepository _humanRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public HumanService(IHumanRepository humanRepository, IConfiguration configuration, IMapper mapper)
    {
        _humanRepository = humanRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<GetHumansResponse> GetHumans(GetHumansRequest request, CancellationToken cancellation)
    {
        var humans = _humanRepository.GetAll();

        return new GetHumansResponse
        {
            Humans = _mapper.Map<IEnumerable<HumanEntity>, IEnumerable<HumanDto>>(humans)
        };
    }

    public async Task<CreateHumanResponse> CreateHuman(CreateHumanRequest request, CancellationToken cancellationToken)
    {
        var human = _mapper.Map<HumanEntity>(request);

        if (human.Birthday > DateTime.Today)
        {
            throw new Exception("Дата рождения не может быть больше текущей");
        }
        
        var humanId = await _humanRepository.AddAsync(human, cancellationToken);

        var createHumanResponse = _mapper.Map<CreateHumanResponse>(request);
        createHumanResponse.Id = humanId;

        return createHumanResponse;
    }
    
    public async Task<DeleteHumanResponse> DeleteHuman(DeleteHumanRequest request, CancellationToken cancellationToken)
    {
        await _humanRepository.DeleteAsync(request.Id, cancellationToken);
        
        return new DeleteHumanResponse();
    }
    
    public async Task<UpdateHumanResponse> UpdateHuman(UpdateHumanRequest request, CancellationToken cancellationToken)
    {
        var human = _mapper.Map<HumanEntity>(request);
        
        if (human.Birthday > DateTime.Today)
        {
            throw new Exception("Дата рождения не может быть больше текущей");
        }
        
        await _humanRepository.UpdateAsync(human, cancellationToken);

        return _mapper.Map<UpdateHumanResponse>(request);
    }

    public async Task<GetHumanByIdResponse> GetHumanById(GetHumanByIdRequest request, CancellationToken cancellation)
    {
        var human = await _humanRepository.GetByIdAsync(request.Id, cancellation);
        
        return _mapper.Map<GetHumanByIdResponse>(human);
    }
}