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
        CreateMap<CreateHumanRequest, HumanEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ModifyDate, opt => opt.Ignore())
            .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => DateTime.ParseExact(src.Birthday, "dd.MM.yyyy", CultureInfo.InvariantCulture)));

        CreateMap<CreateHumanRequest, CreateHumanResponse>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
          

        CreateMap<UpdateHumanRequest, HumanEntity>()
            .ForMember(dest => dest.ModifyDate, opt => opt.Ignore())
            .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => DateTime.ParseExact(src.Birthday, "dd.MM.yyyy", CultureInfo.InvariantCulture)));



        CreateMap<HumanEntity, HumanDto>()
            .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.ToString("dd.MM.yyyy")));


        CreateMap<HumanEntity, GetHumanByIdResponse>()
            .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.ToString("dd.MM.yyyy")));


    }
}