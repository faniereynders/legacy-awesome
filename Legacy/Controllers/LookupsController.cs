using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Legacy.Controllers
{
    [RoutePrefix("api/lookups")]
    public class LookupsController : ApiController
    {
        [HttpGet, Route("countries")]
        public string[] Countries()
        {
            return new string[]
            {
                "AAA",
                "SSS"
            };
        }
    }
}
