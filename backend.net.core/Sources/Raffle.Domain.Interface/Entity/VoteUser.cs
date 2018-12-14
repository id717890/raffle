namespace Raffle.Domain.Interface.Entity
{
    public class VoteUser: Entity
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Vote Vote { get; set; }
        public long VoteId { get; set; }
        public bool Value { get; set; }
    }
}
