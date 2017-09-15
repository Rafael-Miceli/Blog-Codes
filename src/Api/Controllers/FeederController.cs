using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Data;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class FeederController : Controller
    {
        private readonly IFeederService _feederService;

        public FeederController(IFeederService feederService)
        {
            _feederService = feederService; //new FeederService(new FeederSqlServerRepository());
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Feeder> Get()
        {
            return _feederService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Feeder feeder)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
