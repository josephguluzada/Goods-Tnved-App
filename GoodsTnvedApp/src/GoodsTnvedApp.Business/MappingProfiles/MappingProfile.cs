using AutoMapper;
using GoodsTnvedApp.Business.DTOs.GoodDTOs;
using GoodsTnvedApp.Core.Entities;

namespace GoodsTnvedApp.Business.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Good, GoodGetDTO>().ReverseMap();
    }
}