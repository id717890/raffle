using AutoMapper;
using Raffle.Domain.Interface.Entity;

namespace Raffle.Api.ViewModels.Mappings
{
    public class VoteModelProfile: Profile
    {
        public VoteModelProfile()
        {
            CreateMap<Vote, VoteViewModel.Vote>()
                .ForMember(d => d.GiftImage, s => s.MapFrom(x => x.Gift.Image))
                .ForMember(d => d.GiftImageLocal, s => s.MapFrom(x => x.Gift.ImageLocal))
                .ForMember(d => d.GiftName, s => s.MapFrom(x => x.Gift.Name)).ReverseMap();

                //.ForMember(d => d, s => s.MapFrom(x => x.operation_id))
                ////.ForMember(d => d.Amount, s => s.MapFrom(x => x.amount))
                //.ForMember(d => d.WithdrawAmount, s => s.MapFrom(x => x.withdraw_amount))
                ////.ForMember(d => d.Codepro, s => s.MapFrom(x => x.codepro))
                //.ForMember(d => d.Date, s => s.MapFrom(x => x.datetime))
                ////.ForMember(d => d.Label, s => s.MapFrom(x => x.label))
                //.ForMember(d => d.Sender, s => s.MapFrom(x => x.email))
                //.ForMember(d => d.Sha1Hash, s => s.MapFrom(x => x.sha1_hash))
                ////.ForMember(d => d.Unaccepted, s => s.MapFrom(x => x.unaccepted))
                ////.ForMember(d => d.Currency, s => s.MapFrom(x => x.currency))
                //.ForMember(d => d.NotificationType, s => s.MapFrom(x => x.notification_type))
                ;
        }
    }
}
