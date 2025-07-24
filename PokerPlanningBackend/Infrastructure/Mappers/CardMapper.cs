using System;
using AutoMapper;
using PokerPlanningBackend.Domain.Entities;
using PokerPlanningBackend.Infrastructure.EntityFramework.Entities;

namespace PokerPlanningBackend.Infrastructure.Mappers;

public class CardMapper : Profile
{
    public CardMapper()
    {
        CreateMap<Card, CardDAO>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();
    }
}
