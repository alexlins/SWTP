using Microsoft.AspNetCore.Mvc;
using StarShipAPI.Service;
using SWTP.Application.Interfaces;
using SWTP.Application.ViewModels.Response;
using System.Collections.Generic;

namespace StarShipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarShipController : ControllerBase
    {
        private readonly StarShipService starShipService;
        private readonly IStarShipApplication _starShipApplication;
        public StarShipController(IStarShipApplication starShipApplication)
        {
            _starShipApplication = starShipApplication;
            starShipService = new StarShipService(_starShipApplication);
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<StarShipResponseViewModel> Get()
        {
            return starShipService.GetAll();
        }

        [HttpGet("getstops/{distance}")]
        public IEnumerable<StarShipStopResponseViewModel> GetAllStops(long distance)
        {
            return starShipService.GetAllStops(distance);
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
