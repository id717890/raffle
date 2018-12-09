using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public PayController(IMessageModelBuilder messageModelBuilder, IOrderService orderService)
        {
            _messageModelBuilder = messageModelBuilder;
            _orderService = orderService;
        }


        [HttpPost, AllowAnonymous, Route("notify")]
        public async Task<IActionResult> Notify([FromBody]OrderViewModel.YandexHttpNotify model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _orderService.CreateAsync(new Order()
                {
                    Date = model.Date,
                    NotificationType = model.NotificationType,
                    OperationId = model.OperationId
                });
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(_messageModelBuilder.CreateModel("500", e.Message));
            }

        }
    }
}