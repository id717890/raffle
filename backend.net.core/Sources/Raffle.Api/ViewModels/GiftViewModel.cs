namespace Raffle.Api.ViewModels
{
    public class GiftViewModel
    {
        public class GiftDraw
        {
            public long Id { get; set; }
            public string GiftName { get; set; }
            public string GiftDescription { get; set; }
            public string Image { get; set; }
            public string ImageLocal { get; set; }
            public string Info { get; set; }
            public decimal Price { get; set; }
            public decimal PriceKey { get; set; }
            public decimal Reached { get; set; }

        }
    }
}
