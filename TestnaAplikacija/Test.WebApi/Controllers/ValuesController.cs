using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Test.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            {
                IList<string> formatters = new List<string>();

                foreach (var item in GlobalConfiguration.Configuration.Formatters)
                {
                    formatters.Add(item.ToString());
                }

                return formatters.AsEnumerable<string>();
            }
        }

        // GET api/values/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST api/values
        public string Post(Animal animal)
        {
            return animal.Name + ": " + animal.Species;
        }
        [HttpPut]
        [Route("update")]
        // PUT api/values/5
        public void UpdateAnimal(int id, [FromBody] string value)
        {
        }
        [HttpDelete]
        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
    }
}