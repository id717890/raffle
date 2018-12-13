using AutoMapper;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Api.ViewModels.Mappings
{
    public class GiftModelProfile: Profile
    {
        public GiftModelProfile()
        {
            CreateMap<GiftDraw, GiftViewModel.GiftDraw>()
                .ForMember(d => d.ImageLocal, s => s.MapFrom(x => x.Gift.ImageLocal))
                .ForMember(d => d.Image, s => s.MapFrom(x => x.Gift.Image))
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Gift.Id))
                .ForMember(d => d.GiftName, s => s.MapFrom(x => x.Gift.Name))
                .ForMember(d => d.GiftDescription, s => s.MapFrom(x => x.Gift.Description));
        }
    }
}
