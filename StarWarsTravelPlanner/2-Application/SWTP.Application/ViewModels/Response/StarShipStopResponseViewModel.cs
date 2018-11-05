using System;
using System.Collections.Generic;
using System.Text;

namespace SWTP.Application.ViewModels.Response
{
    public class StarShipStopResponseViewModel
    {
        public int StarShipCode { get; set; }
        public string Name { get; set; }
        public string Stops { get; set; }
        public string Message { get; set; }
    }
}
