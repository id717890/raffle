using System;

namespace Raffle.Domain.Interface.Entity
{
    public class Order: Entity
    {
        public string OperationId { get; set; }
        public string NotificationType { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal WithdrawAmount { get; set; }
        public string Currency { get; set; }
        public string Sender { get; set; }
        public bool Codepro { get; set; }
        public string Label { get; set; }
        public string Sha1Hash { get; set; }
        public bool Unaccepted { get; set; }
    }
}
