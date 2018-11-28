using System.Collections.Generic;
using Raffle.Infrastructure.Interface;

namespace Raffle.Infrastructure
{
    public class MessageModelBuilder : IMessageModelBuilder
    {
        public IDictionary<string, string[]> CreateModel(string code, string message)
        {
            return new Dictionary<string, string[]> { { code, new[] { message } } };
        }

        public IDictionary<string, string[]> CreateModel(string code, string[] messages)
        {
            return new Dictionary<string, string[]> { { code, messages } };

        }
    }
}
