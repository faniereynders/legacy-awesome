using Microsoft.AspNetCore.Mvc;

namespace Awesome.Controllers
{
    [Route("api/[controller]")]
    public class LookupsController
    {
        [HttpGet("countries")]
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
