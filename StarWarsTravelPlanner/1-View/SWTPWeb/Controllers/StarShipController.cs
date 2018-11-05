using Microsoft.AspNetCore.Mvc;
using SWTP.Application.Interfaces;
using SWTP.Application.ViewModels.Response;
using SWTPWeb.Services;
using System.Collections.Generic;

namespace SWTPWeb.Controllers
{
    [Route("api/[controller]")]
    public class StarShipController : Controller
    {

        private readonly StarShipService starShipService;
        private readonly IStarShipApplication _starShipApplication;

        public StarShipController(IStarShipApplication starShipApplication)
        {
            _starShipApplication = starShipApplication;
            starShipService = new StarShipService(_starShipApplication);
        }

        [HttpGet("[action]/{distance}")]
        public IEnumerable<StarShipStopResponseViewModel> StarShipStops(string distance)
        {
            long nDistance = -1;

            if (!long.TryParse(distance, out nDistance))
            {
                return new List<StarShipStopResponseViewModel>();
            }
            else
            {
                return starShipService.GetAllStops(nDistance);
            }
        }

        [HttpGet("[action]")]
        public IEnumerable<StarShipStopResponseViewModel> StarShipStops()
        {
            return new List<StarShipStopResponseViewModel>();
        }
    }
}
