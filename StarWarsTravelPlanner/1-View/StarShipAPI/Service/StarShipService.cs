using SWTP.Application.Interfaces;
using SWTP.Application.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarShipAPI.Service
{
    public class StarShipService
    {
        private readonly IStarShipApplication _starShipApplication;

        public StarShipService(IStarShipApplication starShipApplication)
        {
            _starShipApplication = starShipApplication;
        }

        public IEnumerable<StarShipResponseViewModel> GetAll()
        {
            return _starShipApplication.GetAll();
        }

        internal IEnumerable<StarShipStopResponseViewModel> GetAllStops(long distance)
        {
            return _starShipApplication.GetAllStops(distance);
        }
    }
}
