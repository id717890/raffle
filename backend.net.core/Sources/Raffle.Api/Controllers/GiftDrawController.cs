using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raffle.Api.ViewModels;
using Raffle.Domain.Interface.Entity;
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
        private readonly IMapper _mapper;

        public GiftDrawController(IGiftDrawService giftDrawService, IMessageModelBuilder messageModelBuilder, IMapper mapper)
        {
            _giftDrawService = giftDrawService;
            _messageModelBuilder = messageModelBuilder;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<GiftDraw>, IEnumerable<GiftViewModel.GiftDraw>>(
                    await _giftDrawService.GetAllGifts())); ;
            }
            catch (Exception e)
            {
                return BadRequest(_messageModelBuilder.CreateModel("500", e.Message));
            }
        }
    }
}