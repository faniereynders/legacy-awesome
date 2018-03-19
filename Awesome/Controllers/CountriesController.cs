using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Awesome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController
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
        public ActionResult Post(Country country)
        {
            countries.Add(country);
            return new OkResult();
            
        }

        public IEnumerable<Country> Get()
        {
            return countries;
        }

        [HttpGet("{code}")]
        public ActionResult<Country> Get(string code)
        {
            var country = countries.SingleOrDefault(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
            if (country == null)
            {
                return new NotFoundResult();
            }
            return country;
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
