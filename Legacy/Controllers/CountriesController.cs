using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http;

namespace Legacy.Controllers
{
    [RoutePrefix("api/countries")]
    public class CountriesController : ApiController
    {
        private static List<Country> countries;

        public CountriesController()
        {
            if (countries == null)
            {
                countries = new List<Country>
                {
                    new Country{ Code = "NL", Name = "Netherlands"},
                    new Country{ Code = "US", Name = "United States"}
                };
            }

        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            countries.Add(country);
            return Ok();

        }

        public IEnumerable<Country> Get()
        {
            return countries;
        }

        [Route("{code}")]
        public IHttpActionResult Get([FromUri]string code)
        {
            var country = countries.SingleOrDefault(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
    }

    public class Country
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
