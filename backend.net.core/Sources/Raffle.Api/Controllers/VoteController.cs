using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raffle.Domain.Interface.Services;
using Raffle.Infrastructure.Interface;

namespace Raffle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;
        private readonly IMessageModelBuilder _messageModelBuilder;

        public VoteController(IVoteService voteService, IMessageModelBuilder messageModelBuilder)
        {
            _voteService = voteService;
            _messageModelBuilder = messageModelBuilder;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _voteService.GetAllGifts());
            }
            catch (Exception e)
            {
                return BadRequest(_messageModelBuilder.CreateModel("500", e.Message));
            }

        }
    }
}