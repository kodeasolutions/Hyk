using Hyk_WebApi.Models.AvailableTrips;
using Hyk_WebApi.Models.AvailableTrips.Models;
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
        // GET: api/AvailableTrips
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AvailableTrips/5
        public TripResponseList Get(TripRequestAddresses tripRequest)
        {
            if (tripRequest != null)
            {
              
            }

            AvailableTripsHandler handler = new AvailableTripsHandler();
            TripResponseList tripResponse = new TripResponseList();

            return tripResponse;
        }

        // POST: api/AvailableTrips
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AvailableTrips/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AvailableTrips/5
        public void Delete(int id)
        {
        }
    }
}
