namespace Raffle.Domain.Interface.Entity
{
    public class Customer : Entity
    {
        public string IdentityId { get; set; }
        public ApplicationUser Identity { get; set; }  // navigation property
        public string Location { get; set; }
        public string Locale { get; set; }
        public string Gender { get; set; }
    }
}
