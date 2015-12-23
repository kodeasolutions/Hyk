using Hyk_WebApi.Models.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyk_WebApi.Models.AvailableTrips.Models
{
    public class TripRequestAddresses
    {
        public int userType { get; set; } //driver or passegner
        public Addresses addresses { get; set; } //start, stop over, end
    }
}