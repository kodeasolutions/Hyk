﻿using Google.Geolocation.Api;
using Hyk_WebApi.Models.AvailableTrips;
using Hyk_WebApi.Models.AvailableTrips.Models;
using Hyk_WebApi.Models.Tools.Google_Geolocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hyk_WebApi.Controllers
{
    public class AvailableTripsController : ApiController
    {
        // GET: api/AvailableTrips/5
        [HttpGet]
        public TripResponseList Get(TripRequestAddresses tripRequest)
        {
            AvailableTripsHandler handler = new AvailableTripsHandler();     
            return handler.findTrips(tripRequest);
        }
    }
}
