using System;

namespace Raffle.Infrastructure.Interface
{
    public interface IEmailBuilder
    {
        string CreateConfirmEmailBody(string url);

    }
}
