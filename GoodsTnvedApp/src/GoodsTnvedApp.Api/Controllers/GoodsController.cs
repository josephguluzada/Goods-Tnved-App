using GoodsTnvedApp.Business.DTOs.GoodDTOs;
using GoodsTnvedApp.Business.GoodsTnvedAppExceptions;
using GoodsTnvedApp.Business.Services.Abstracts;
using GoodsTnvedApp.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodsTnvedApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodService _goodService;

        public GoodsController(IGoodService goodService)
        {
            _goodService = goodService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetGoods(string code)
        {
            GoodGetDTO data = null;

            try
            {
                data = await _goodService.GetGoods(code);
            }
            catch (InvalidGoodCodeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
            
            return Ok(data);
        }
    }
}
