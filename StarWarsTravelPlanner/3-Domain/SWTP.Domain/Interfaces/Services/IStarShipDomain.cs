using SWTP.Domain.DomainModels;
using System;
using System.Collections.Generic;

namespace SWTP.Domain.Interfaces.Services
{
    public interface IStarShipDomain : IDisposable
    {
        IEnumerable<StarShipDomainModel> GetAll();

        IEnumerable<StarShipStopDomainModel> GetAllStops(long distance);
    }
}
