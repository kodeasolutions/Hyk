using Hyk_WebApi.Models.Entity_Framework_File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyk_WebApi.Models.AvailableTrips.Models
{
    public class AvailableDriverList
    {
        internal int availableSeats;

        public AvailableDriverList()
        {
        }

        public DateTime dateScheduled { get; set; }
        public int tripId { get; set; }
        public string userFirstName { get; set; }
        public PREFERENCE userPreference { get; set; }
        public string userProfilePicture { get; set; }
    }
}