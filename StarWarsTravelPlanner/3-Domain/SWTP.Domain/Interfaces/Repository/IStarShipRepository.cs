using SWTP.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWTP.Domain.Interfaces.Repository
{
    public interface IStarShipRepository : IDisposable
    {
        IEnumerable<StarShipDomainModel> GetAllStarships();
        StarShipDomainModel GetStarShipById(int starshipId);
    }
}
