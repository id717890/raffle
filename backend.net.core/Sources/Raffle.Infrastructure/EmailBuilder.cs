using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Raffle.Infrastructure.Interface;

namespace Raffle.Infrastructure
{
    public class EmailBuilder : IEmailBuilder
    {
        private IHostingEnvironment _env;

        public EmailBuilder(IHostingEnvironment env)
        {
            _env = env;
        }

        public string CreateConfirmEmailBody(string url)
        {
            string body = string.Empty;
            //using streamreader for reading my htmltemplate  
            var ss = _env.WebRootPath;
            var sw = _env.ContentRootPath;

            using (StreamReader reader = new StreamReader(_env.ContentRootPath + "/Templates/Email/Confirm.html"))

            {

                body = reader.ReadToEnd();

            }

            //body = body.Replace("{UserName}", userName); //replacing the required things  

            //body = body.Replace("{Title}", title);

            //body = body.Replace("{message}", message);

            return body.Replace("{0}", url);
        }

        public string CreateForgotPasswordEmailBody(string url)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(_env.ContentRootPath + "/Templates/Email/Forgot.html"))
            {
                body = reader.ReadToEnd();
            }
            return body.Replace("{0}", url);
        }
    }
}
