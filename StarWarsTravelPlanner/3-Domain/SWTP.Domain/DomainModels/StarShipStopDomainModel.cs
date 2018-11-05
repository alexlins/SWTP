using System;
using System.Collections.Generic;
using System.Text;

namespace SWTP.Domain.DomainModels
{
    public class StarShipStopDomainModel
    {
        public int StarShipCode { get; set; }
        public string Name { get; set; }
        public int Stops { get; set; }
        public string Message { get; set; }
    }
}
