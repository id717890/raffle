using System;
using System.Collections.Generic;
using System.Text;

namespace Raffle.Domain.Interface.Entity
{
    public class Order: Entity
    {
        public string OperationId { get; set; }
        public string NotificationType { get; set; }
        public DateTime Date { get; set; }
    }
}
