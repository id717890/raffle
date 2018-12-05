namespace Raffle.Domain.Interface.Entity
{
    public class Vote: Entity
    {
        public Gift Gift { get; set; }
        public long GiftId { get; set; }
        public decimal Price { get; set; }
        public long VotesAgree { get; set; }
        public long VotesDisagree { get; set; }
    }
}
