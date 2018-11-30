using System.Collections;
using System.Collections.Generic;

namespace Raffle.Domain.Interface.Entity
{
    public class Gift: Entity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public ICollection<GiftDraw> GiftDraws { get; set; }
    }
}
