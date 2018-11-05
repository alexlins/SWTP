using SWTP.Domain.DomainModels;
using SWTP.Domain.Interfaces.Repository;
using SWTP.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWTP.Domain.Services
{
    public class StarShipDomain : IStarShipDomain
    {
        private readonly IStarShipRepository _starShipRepository;
        public StarShipDomain(IStarShipRepository starShipRepository)
        {
            _starShipRepository = starShipRepository;
        }

        public void Dispose()
        {
            _starShipRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<StarShipDomainModel> GetAll()
        {
            return _starShipRepository.GetAllStarships();
        }

        public IEnumerable<StarShipStopDomainModel> GetAllStops(long distance)
        {
            List<StarShipStopDomainModel> lReturn = new List<StarShipStopDomainModel>();

            var starShipList = GetAll();

            if (!starShipList.Any())
            {
                return lReturn;
            }

            Parallel.ForEach(starShipList, ss =>
             {
                 var item = CalculateStops(distance, ss.Consumables, ss.MGLT);

                 lReturn.Add(
                     new StarShipStopDomainModel
                     {
                         Name = ss.Name,
                         Stops = item,
                         Message = item > -1 ? "ok" : "Information not available",
                         StarShipCode = GetStarShipCode(ss.Url)
                     });
             });

            return lReturn.OrderBy(x=>x.Message);
        }

        public int GetStarShipCode(string url)
        {
            try
            {
                var nUrl = url.EndsWith('/') ? url.Remove(url.Length - 1) : url;
                return Convert.ToInt16(nUrl.Substring(nUrl.LastIndexOf('/') + 1).Replace("/", ""));
            }
            catch
            {
                return -1;
            }
        }

        public int CalculateStops(long distance, string consumables, string MGLT)
        {
            var consumablesHourRating = ConvertToHourRate(consumables.ToLower());
            if (consumablesHourRating == -1)
                return -1;

            long nMGLT = 0;

            if (!long.TryParse(MGLT, out nMGLT))
                return -1;

            long autonomy = nMGLT * consumablesHourRating;

            double rate = distance / autonomy;

            return Convert.ToInt32(Math.Truncate(rate));
        }

        public long ConvertToHourRate(string consumables)
        {
            long numberPart = -1;
            if (consumables.Contains("year"))
            {
                numberPart = Convert.ToInt64(consumables.Substring(0, consumables.IndexOf('y')).Trim());
                return numberPart * 365 * 24;
            }

            if (consumables.Contains("month"))
            {
                numberPart = Convert.ToInt64(consumables.Substring(0, consumables.IndexOf('m')).Trim());
                return numberPart * 30 * 24;
            }

            if (consumables.Contains("week"))
            {
                numberPart = Convert.ToInt64(consumables.Substring(0, consumables.IndexOf('w')).Trim());
                return numberPart * 7 * 24;
            }

            if (consumables.Contains("day"))
            {
                numberPart = Convert.ToInt64(consumables.Substring(0, consumables.IndexOf('d')).Trim());
                return numberPart * 24;
            }

            if (consumables.Contains("hour"))
            {
                numberPart = Convert.ToInt64(consumables.Substring(0, consumables.IndexOf('h')).Trim());
                return numberPart;
            }
            
            return long.TryParse(consumables, out numberPart) ? numberPart : -1;
        }
    }
}

