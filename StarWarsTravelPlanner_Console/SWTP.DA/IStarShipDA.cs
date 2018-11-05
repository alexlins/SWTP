using SWTP.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWTP.DA
{
    public interface IStarShipDA
    {
        IEnumerable<StarShipDto> GetAllStarships();
    }
}
