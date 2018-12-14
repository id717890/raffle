namespace Raffle.Domain.Interface.Entity
{
    public class GiftDraw: Entity
    {
        public Gift Gift { get; set; }
        public long GiftId { get; set; }
        public string Info { get; set; }
        public decimal Price { get; set; }
        public decimal PriceKey { get; set; }
        public decimal Reached { get; set; }
    }
}
