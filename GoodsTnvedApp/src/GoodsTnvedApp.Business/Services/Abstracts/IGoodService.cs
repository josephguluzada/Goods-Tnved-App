using GoodsTnvedApp.Business.DTOs.GoodDTOs;
using GoodsTnvedApp.Core.Entities;

namespace GoodsTnvedApp.Business.Services.Abstracts;

public interface IGoodService
{
    public Task<GoodGetDTO> GetGoods(string? code); 
}