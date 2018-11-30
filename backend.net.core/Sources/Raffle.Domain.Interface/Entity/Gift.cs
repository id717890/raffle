using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Raffle.Domain.Interface.Entity
{
    public class Gift: Entity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<GiftDraw> GiftDraws { get; set; }
    }
}
