using System.Collections.Generic;

namespace Raffle.Infrastructure.Interface
{
    public interface IMessageModelBuilder
    {
        IDictionary<string, string[]> CreateModel(string code, string message);
        IDictionary<string, string[]> CreateModel(string code, string[] messages);
    }
}