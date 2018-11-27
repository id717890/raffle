using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Raffle.Api.Helpers;

namespace Raffle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values
        [HttpGet, Authorize, Route("test")]
        public ActionResult<IEnumerable<string>> Test()
        {
            return new string[] { "value22", "value22" };
        }

        // GET api/values
        [HttpGet, Authorize(Roles = Constants.StandartRole), Route("test3")]
        public ActionResult<IEnumerable<string>> Test3()
        {
            return new string[] { "valueGUEST" };
        }

        // GET api/values
        [HttpGet, Authorize(Roles = "admin"), Route("test4")]
        public ActionResult<IEnumerable<string>> Test4()
        {
            return new string[] { "value ADMIN" };
        }

        // GET api/values
        [HttpGet, Route("test2")]
        public ActionResult<IEnumerable<string>> Test2()
        {
            return new string[] { "value33", "value33" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
