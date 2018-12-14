using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raffle.Domain.Interface.Entity;
using Raffle.Domain.Interface.Services;
using Raffle.Infrastructure.Interface;

namespace Raffle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IMessageModelBuilder _messageModelBuilder;
        private readonly IGiftDrawUserKeyService _giftDrawUserKeyService;
        private readonly IGiftDrawService _giftDrawService;
        private readonly UserManager<ApplicationUser> _userManager;


        public InfoController(IMessageModelBuilder messageModelBuilder, IGiftDrawUserKeyService giftDrawUserKeyService, IGiftDrawService giftDrawService, UserManager<ApplicationUser> userManager)
        {
            _messageModelBuilder = messageModelBuilder;
            _giftDrawUserKeyService = giftDrawUserKeyService;
            _giftDrawService = giftDrawService;
            _userManager = userManager;
        }

        [HttpGet, Route("TotalInfo")]
        public async Task<IActionResult> TotalInfo()
        {
            try
            {
                return Ok(new { totalUsers = await _userManager.Users.CountAsync(), totalGifts = await _giftDrawService.GetCountOfGifts(), totalKeys = await _giftDrawUserKeyService.GetCountOfKeys()});
            }
            catch (Exception e)
            {
                return BadRequest(_messageModelBuilder.CreateModel("500", e.Message));
            }
        }
    }
}