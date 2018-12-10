using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Raffle.Api.ViewModels;
using Raffle.Domain.Interface.Entity;
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
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;


        public VoteController(IVoteService voteService, IMessageModelBuilder messageModelBuilder, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _voteService = voteService;
            _messageModelBuilder = messageModelBuilder;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var map = _mapper.Map<IEnumerable<VoteViewModel.Vote>>(await _voteService.GetAllGifts());

                return Ok(map);
            }
            catch (Exception e)
            {
                return BadRequest(_messageModelBuilder.CreateModel("500", e.Message));
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Post(VoteViewModel.VoteUser model)
        {
            try
            {
                var findUser = await _userManager.FindByIdAsync(model.UserId);
                if (findUser == null) return NotFound(_messageModelBuilder.CreateModel("404", "ID пользователя не найден"));
                var findVote = await _voteService.FindVoteById(model.Id);
                if (findVote == null) return NotFound(_messageModelBuilder.CreateModel("404", "ID голосования не найден"));

                if (model.IsCancel)
                {
                }
                else
                {
                    var result = await _voteService.AddVote(new VoteUser { Value = model.Value, UserId = findUser.Id, VoteId = findVote.Id });
                    if (result == 0) return NotFound(_messageModelBuilder.CreateModel("500", "Ошибка при сохранении голоса"));
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(_messageModelBuilder.CreateModel("500", e.Message));
            }
        }
    }
}