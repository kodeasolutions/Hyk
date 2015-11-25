using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyk_WebApi.Models.AvailableTrips.Models
{
    public class TripRequestAddresses
    {
        public int userType { get; set; } //driver or passegner
        public string startLocation { get; set; } //start loaction
        public List<string> stopLocation { get; set; } //stop location
        public string endLocation { get; set; } //end location
    }
}