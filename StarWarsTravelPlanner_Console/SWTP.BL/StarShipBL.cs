using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWTP.DA;
using SWTP.DTO;

namespace SWTP.BL
{
    public class StarShipBL : IStarShipBL
    {
        private readonly IStarShipDA starShipDA;

        public StarShipBL()
        {
            starShipDA = new StarShipDA();
        }

        public IEnumerable<StarShipDto> GetAll()
        {
            return starShipDA.GetAllStarships();
        }

        public IEnumerable<StarShipStopDto> GetAllStops(long distance)
        {
            List<StarShipStopDto> lReturn = new List<StarShipStopDto>();

            var starShipList = GetAll();

            if (!starShipList.Any())
            {
                return lReturn;
            }

            foreach (var ss in starShipList)
            {
                var item = CalculateStops(distance, ss.Consumables, ss.MGLT);

                lReturn.Add(
                    new StarShipStopDto
                    {
                        Name = ss.Name,
                        Stops = item,
                        Message = item > -1 ? "ok" : "Information not available",
                        StarShipCode = GetStarShipCode(ss.Url)
                    });
            };

            return lReturn.OrderBy(x=>x.Stops);
        }

        private int GetStarShipCode(string url)
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

        private int CalculateStops(long distance, string consumables, string MGLT)
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

        private long ConvertToHourRate(string consumables)
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
            }

            return numberPart;

        }
    }
}
