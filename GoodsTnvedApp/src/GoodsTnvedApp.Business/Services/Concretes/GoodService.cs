using AutoMapper;
using GoodsTnvedApp.Business.DTOs.GoodDTOs;
using GoodsTnvedApp.Business.GoodsTnvedAppExceptions;
using GoodsTnvedApp.Business.Services.Abstracts;
using GoodsTnvedApp.Core.Entities;
using GoodsTnvedApp.Core.Repositories;

namespace GoodsTnvedApp.Business.Services.Concretes;

public class GoodService : IGoodService
{
    private readonly IGoodRepository _goodRepository;
    private readonly IMapper _mapper;

    public GoodService(IGoodRepository goodRepository, IMapper mapper)
    {
        _goodRepository = goodRepository;
        _mapper = mapper;
    }
    
    public async Task<GoodGetDTO> GetGoods(string? code)
    {
        if(string.IsNullOrWhiteSpace(code))
            throw new InvalidGoodCodeException("Good code can not be null or empty");
        GoodGetDTO dto = null;
        var data = await _goodRepository.GetAll(code);
        if(data is not null) 
            dto = _mapper.Map<GoodGetDTO>(data);
        
        return dto;
    }
}