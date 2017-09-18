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
            _feederService = feederService;
        }

        [HttpGet]
        public IEnumerable<Feeder> Get()
        {
            return _feederService.GetAll();
        }      

        [HttpPost]
        public IActionResult Post([FromBody]Feeder feeder)
        {
            try
            {
                _feederService.Create(feeder);    
                return Created("Aqui vai a URL da onde encontrar o objeto criado respeitando o HATEOAS", feeder);
            }
            catch (Exception ex)
            {                
                return BadRequest(ex.Message);
            } 
        }
       
    }
}
