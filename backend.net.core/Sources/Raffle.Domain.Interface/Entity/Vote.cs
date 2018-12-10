using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Raffle.Domain.Interface.Entity
{
    public class Vote: Entity
    {
        public Gift Gift { get; set; }
        public long GiftId { get; set; }
        public decimal Price { get; set; }
        public long VotesAgree { get; set; }
        public long VotesDisagree { get; set; }

        public ICollection<VoteUser> VoteUsers { get; set; }
    }
}
