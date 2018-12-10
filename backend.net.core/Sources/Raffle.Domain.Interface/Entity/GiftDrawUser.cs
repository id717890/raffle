using System;
using System.Collections.Generic;

namespace Raffle.Domain.Interface.Entity
{
    public class GiftDrawUser:Entity
    {
        public GiftDraw GiftDraw { get; set; }
        public Int64 GiftDrawId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public ICollection<GiftDrawUserKey> Keys { get; set; }
    }
}
