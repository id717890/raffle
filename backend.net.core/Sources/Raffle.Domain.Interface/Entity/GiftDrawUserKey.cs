using System;

namespace Raffle.Domain.Interface.Entity
{
    public class GiftDrawUserKey: Entity
    {
        public GiftDrawUser GiftDrawUser { get; set; }
        public string Key { get; set; }
    }
}
