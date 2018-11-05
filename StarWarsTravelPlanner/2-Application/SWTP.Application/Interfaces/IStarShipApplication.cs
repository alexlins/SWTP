using System;
using System.Collections.Generic;
using System.Text;
using SWTP.Application.ViewModels.Response;

namespace SWTP.Application.Interfaces
{
    public interface IStarShipApplication
    {
        IEnumerable<StarShipResponseViewModel> GetAll();
        IEnumerable<StarShipStopResponseViewModel> GetAllStops(long distance);
    }
}
