using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Raffle.Api.Helpers;
using Raffle.Api.Models;
using Raffle.Api.ViewModels;
using Raffle.Infrastructure.Interface;

namespace Raffle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IEmailBuilder _emailBuilder;

        public AccountController(
            UserManager<ApplicationUser> userManager, 
            IMapper mapper, 
            ApplicationDbContext appDbContext, 
            IEmailSender emailSender,
            IEmailBuilder emailBuilder
            )
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _emailSender = emailSender;
            _emailBuilder = emailBuilder;
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<ApplicationUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(userIdentity);
            var callbackUrl = Url.Action($"ConfirmEmail", $"Account", new { userId = userIdentity.Id, code = code }, protocol: HttpContext.Request.Scheme);
            await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                _emailBuilder.CreateConfirmEmailBody(callbackUrl));
            //await _signInManager.SignInAsync(user, isPersistent: false);


            await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id});
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }

        [HttpGet, Route("ConfirmEmail")]
        public IActionResult ConfirmEmail(string userId, string code)
        {
            return null;
        }
    }
}