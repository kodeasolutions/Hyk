using Hyk_WebApi.Models.Entity_Framework_File;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyk_WebApi.Models.AvailableTrips.Models
{
    public class TripResponseList
    {
        public string status { get; set; }
        public List<AvailableDriverList> DriversFound { get; set; }
        public List<AvailablePassengersList> PassengersFound { get; set; }
    }
}