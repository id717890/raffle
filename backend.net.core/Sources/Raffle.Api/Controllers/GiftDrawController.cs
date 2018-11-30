using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raffle.Domain.Interface.Services;
using Raffle.Infrastructure.Interface;

namespace Raffle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftDrawController : ControllerBase
    {
        private readonly IGiftDrawService _giftDrawService;
        private readonly IMessageModelBuilder _messageModelBuilder;

        public GiftDrawController(IGiftDrawService giftDrawService, IMessageModelBuilder messageModelBuilder)
        {
            _giftDrawService = giftDrawService;
            _messageModelBuilder = messageModelBuilder;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _giftDrawService.GetAllGifts();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(_messageModelBuilder.CreateModel("500", e.Message));
            }
            
        }
    }
}