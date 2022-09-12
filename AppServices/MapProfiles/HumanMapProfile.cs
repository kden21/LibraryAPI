using System.Globalization;
using AutoMapper;
using Contracts.Human.CreateHuman;
using Contracts.Human.Dto;
using Contracts.Human.GetHumanById;
using Contracts.Human.UpdateHuman;
using Domain;

namespace AppServices.MapProfiles;

public class HumanMapProfile : Profile
{
    public HumanMapProfile()
    {
        CreateMap<HumanEntity, HumanDto>()
            .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.ToString("dd.MM.yyyy")));
    }
}