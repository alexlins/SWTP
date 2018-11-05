using SWTP.Application.Interfaces;
using SWTP.Application.ViewModels.Response;
using SWTP.Domain.DomainModels;
using SWTP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWTP.Application.Services
{
    public class StarShipApplication : IStarShipApplication
    {
        private readonly IStarShipDomain _starShipDomain;
        public StarShipApplication(IStarShipDomain starShipDomain)
        {
            _starShipDomain = starShipDomain;
        }

        
        public IEnumerable<StarShipResponseViewModel> GetAll()
        {
            var ssDomainList = _starShipDomain.GetAll();
            return ConvertToStarShipResponseViewModelList(ssDomainList);
        }

        public IEnumerable<StarShipStopResponseViewModel> GetAllStops(long distance)
        {
            var ssDomainList = _starShipDomain.GetAllStops(distance);
            return ConvertToStarShipStopResponseViewModelList(ssDomainList);
        }


        #region private
        private IEnumerable<StarShipResponseViewModel> ConvertToStarShipResponseViewModelList(IEnumerable<StarShipDomainModel> starShipList)
        {
            var listResponse = new List<StarShipResponseViewModel>();
            if (starShipList == null)
                return listResponse;


            Parallel.ForEach(starShipList, x =>
            {
                listResponse.Add(new StarShipResponseViewModel
                {
                    Pilots = x.Pilots,
                    Consumables = x.Consumables,
                    Cargo_capacity = x.Cargo_capacity,
                    Name = x.Name,
                    Url = x.Url,
                    Created = x.Created,
                    Edited = x.Edited,
                    Crew = x.Crew,
                    Max_atmosphering_speed = x.Max_atmosphering_speed,
                    Passengers = x.Passengers,
                    Vehicle_class = x.Vehicle_class,
                    Cost_in_credits = x.Cost_in_credits,
                    Model = x.Model,
                    Films = x.Films,
                    Manufacturer = x.Manufacturer,
                    Length = x.Length,
                    Hyperdrive_rating = x.Hyperdrive_rating,
                    MGLT = x.MGLT,
                    Starship_class = x.Starship_class
                });
            });

            return listResponse;
        }

        private IEnumerable<StarShipStopResponseViewModel> ConvertToStarShipStopResponseViewModelList(IEnumerable<StarShipStopDomainModel> starShipList)
        {
            var listResponse = new List<StarShipStopResponseViewModel>();
            if (starShipList == null)
                return listResponse;

            Parallel.ForEach(starShipList, x =>
            {
                listResponse.Add(new StarShipStopResponseViewModel
                {
                    Name = x.Name,
                    StarShipCode = x.StarShipCode,
                    Stops = x.Stops==-1?"n/a":x.Stops.ToString(),
                    Message = x.Message
                });
            });

            return listResponse;
        }

        #endregion

        public void Dispose()
        {
            _starShipDomain.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
