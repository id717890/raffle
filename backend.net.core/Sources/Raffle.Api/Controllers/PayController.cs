using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raffle.Api.ViewModels;
using Raffle.Domain.Interface.Entity;
using Raffle.Domain.Interface.Services;
using Raffle.Infrastructure.Interface;

namespace Raffle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IMessageModelBuilder _messageModelBuilder;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public PayController(IMessageModelBuilder messageModelBuilder, IOrderService orderService, IMapper mapper)
        {
            _messageModelBuilder = messageModelBuilder;
            _orderService = orderService;
            _mapper = mapper;
        }


        [HttpPost, AllowAnonymous, Route("notify")]
        public async Task<IActionResult> Notify([FromForm]OrderViewModel.YandexHttpNotify model)
        {
            try
            {
                var order = _mapper.Map<Order>(model);
                if (order.Label == null)
                {
                    order.Label = "empty";
                }
                await _orderService.CreateAsync(order);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(_messageModelBuilder.CreateModel("500", e.Message));
            }

        }
    }
}