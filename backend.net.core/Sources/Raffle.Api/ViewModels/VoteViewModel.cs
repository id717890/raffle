using Newtonsoft.Json;

namespace Raffle.Api.ViewModels
{
    public class VoteViewModel
    {
        public class Vote
        {
            public long Id { get; set; }
            public decimal Price { get; set; }
            public long VotesAgree { get; set; }
            public long VotesDisagree { get; set; }
            public long GiftId { get; set; }
            public string GiftName { get; set; }
            public string GiftImage { get; set; }
            public string GiftImageLocal { get; set; }
            public bool? UserVote { get; set; }
        }

        [JsonObject]
        public class VoteUser
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("value")]
            public bool Value { get; set; }

            [JsonProperty("isCancel")]
            public bool IsCancel { get; set; }
        }
    }
}
