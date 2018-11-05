using SWTP.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWTP.BL
{
    public interface IStarShipBL
    {
        IEnumerable<StarShipDto> GetAll();
        IEnumerable<StarShipStopDto> GetAllStops(long distance);
    }
}
