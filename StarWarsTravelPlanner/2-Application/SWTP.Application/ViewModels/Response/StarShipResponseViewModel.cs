using System;
using System.Collections.Generic;
using System.Text;

namespace SWTP.Application.ViewModels.Response
{
    public class StarShipResponseViewModel
    {

        /// <summary>
        /// An array of People URL Resources that this vehicle has been piloted by.
        /// </summary>
        public List<string> Pilots { get; set; }

        /// <summary>
        /// The maximum length of time that this vehicle can provide consumables for it's entire crew without having to resupply.
        /// </summary>
        public string Consumables { get; set; }

        /// <summary>
        /// The maximum number of kilograms that this vehicle can transport.
        /// </summary>
        public string Cargo_capacity { get; set; }

        /// <summary>
        /// The name of this vehicle.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The hypermedia URL of this resource.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// the ISO 8601 date format of the time that this resource was created.
        /// </summary>
        public string Created { get; set; }

        /// <summary>
        /// the ISO 8601 date format of the time that this resource was edited.
        /// </summary>
        public string Edited { get; set; }

        /// <summary>
        /// The number of personnel needed to run or pilot this vehicle.
        /// </summary>
        public string Crew { get; set; }

        /// <summary>
        /// The maximum speed of this vehicle in atmosphere.
        /// </summary>
        public string Max_atmosphering_speed { get; set; }

        /// <summary>
        /// The number of non-essential people this vehicle can transport.
        /// </summary>
        public string Passengers { get; set; }

        /// <summary>
        /// The class of this vehicle, such as Wheeled.
        /// </summary>
        public string Vehicle_class { get; set; }

        /// <summary>
        /// The cost of this vehicle new, in galactic credits.
        /// </summary>
        public string Cost_in_credits { get; set; }

        /// <summary>
        /// The model or official name of this vehicle. Such as All Terrain Attack Transport.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// The model or official name of this vehicle. Such as All Terrain Attack Transport.
        /// </summary>
        public List<string> Films { get; set; }

        /// <summary>
        /// The manufacturer of this vehicle. Comma seperated if more than one.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// The length of this vehicle in meters.
        /// </summary>
        public string Length { get; set; }

        public string Starship_class { get; set; }

        public string Hyperdrive_rating { get; set; }

        public string MGLT { get; set; }
    }
}
