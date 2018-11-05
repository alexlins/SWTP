using System;
using System.Collections.Generic;
using SharpTrooper.Core;
using SharpTrooper.Entities;
using SWTP.DTO;

namespace SWTP.DA
{
    public class StarShipDA : IStarShipDA
    {
        public IEnumerable<StarShipDto> GetAllStarships()
        {
            bool nextPage = true;
            var pageCount = 1;
            var starShipList = new List<Starship>();

            try
            {
                while (nextPage)
                {
                    var resultado = new SharpTrooperCore().GetAllStarships(pageCount.ToString());
                    starShipList.AddRange(resultado.results);

                    if (resultado.nextPageNo == null)
                    {
                        nextPage = false;
                    }

                    pageCount++;
                }

                return ConvertToStarShipDtoList(starShipList);
            }
            catch
            {
                return new List<StarShipDto>();
            }
        }

        private IEnumerable<StarShipDto> ConvertToStarShipDtoList(List<Starship> starShipList)
        {
            var listDomain = new List<StarShipDto>();
            if (starShipList.Count < 1)
            {
                return listDomain;
            }

            starShipList.ForEach(x =>
            {
                listDomain.Add(new StarShipDto
                {
                    Pilots = x.pilots,
                    Consumables = x.consumables,
                    Cargo_capacity = x.cargo_capacity,
                    Name = x.name,
                    Url = x.url,
                    Created = x.created,
                    Edited = x.edited,
                    Crew = x.crew,
                    Max_atmosphering_speed = x.max_atmosphering_speed,
                    Passengers = x.passengers,
                    Vehicle_class = x.vehicle_class,
                    Cost_in_credits = x.cost_in_credits,
                    Model = x.model,
                    Films = x.films,
                    Manufacturer = x.manufacturer,
                    Length = x.length,
                    Hyperdrive_rating = x.hyperdrive_rating,
                    MGLT = x.MGLT,
                    Starship_class = x.starship_class
                });
            });

            return listDomain;
        }

    }
}
