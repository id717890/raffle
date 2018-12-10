using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Raffle.Domain.Interface.Services;
using Raffle.Infrastructure.Interface;

namespace Raffle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMessageModelBuilder _messageModelBuilder;
        private readonly IGiftDrawUserKeyService _giftDrawUserKeyService;

        public InfoController(IMapper mapper, IMessageModelBuilder messageModelBuilder, IGiftDrawUserKeyService giftDrawUserKeyService)
        {
            _mapper = mapper;
            _messageModelBuilder = messageModelBuilder;
            _giftDrawUserKeyService = giftDrawUserKeyService;
        }

        [HttpGet, Route("TotalInfo")]
        public async Task<IActionResult> TotalInfo()
        {
            try
            {
                return Ok(new { totalUsers = 999, totalGifts = 999, totalKeys = await _giftDrawUserKeyService.GetCountOfKeys()});
            }
            catch (Exception e)
            {
                return BadRequest(_messageModelBuilder.CreateModel("500", e.Message));
            }
        }
    }
}