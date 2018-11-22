using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using Raffle.Api.ViewModels.Validations;

namespace Raffle.Api.ViewModels
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
