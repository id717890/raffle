using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Raffle.Api.ViewModels
{
    public class OrderViewModel
    {
        public class YandexHttpNotify
        {
            [Required, JsonProperty("operation_id")]
            public string OperationId { get; set; }

            [JsonProperty("notification_type")]
            public string NotificationType { get; set; }

            [Required, JsonProperty("datetime")]
            public DateTime Date { get; set; }
        }
    }
}
