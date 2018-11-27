using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Raffle.Api.Models;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Api.ViewModels.Mappings
{
  public class ViewModelToEntityMappingProfile: Profile
  {
    public ViewModelToEntityMappingProfile()
    {
      CreateMap<RegistrationViewModel, ApplicationUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
    }
  }
}
