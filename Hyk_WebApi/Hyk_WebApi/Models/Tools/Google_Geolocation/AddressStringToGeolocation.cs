using Google.Geolocation.Api;
using Hyk_WebApi.Models.AvailableTrips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyk_WebApi.Models.Tools.Google_Geolocation
{
    public class AddressStringToGeolocation
    {
        public List<Geolocation> convert(Addresses requestAddresses, ref string responseStatus) //works with next method
        {
            Google_Geolocation_Api google_geo_api = new Google_Geolocation_Api();
            List<Geolocation> listOfRequestGeolocations = new List<Geolocation>();
            Geolocation tempGeolocation;

            tempGeolocation = google_geo_api.locate(requestAddresses.startLocation); //get geoloaction of start from google
            if (!(validateGoogleApiResponse("StartLocation", tempGeolocation, ref responseStatus)))
            {
                return null;
            }
            listOfRequestGeolocations.Add(tempGeolocation);

            if (requestAddresses.stopLocation != null)
            {
                int index = 0;
                foreach (string reqAddress in requestAddresses.stopLocation)
                {
                    index++;
                    tempGeolocation = google_geo_api.locate(reqAddress);
                    if (!(validateGoogleApiResponse("StopLocation" + index, tempGeolocation, ref responseStatus)))
                    {
                        return null;
                    }
                    listOfRequestGeolocations.Add(tempGeolocation);
                }
            }

            tempGeolocation = google_geo_api.locate(requestAddresses.endLocation); //get geoloaction of end from google
            if (!(validateGoogleApiResponse("EndLocation", tempGeolocation, ref responseStatus)))
            {
                return null;
            }
            listOfRequestGeolocations.Add(tempGeolocation);

            return listOfRequestGeolocations;
        }

        private bool validateGoogleApiResponse(String message, Geolocation geoloaction, ref string respondStatus)
        {
            if (geoloaction == null)
            {
                respondStatus = "GoogleGeoloactionUnavailable";
                return false;
            }

            if (!(geoloaction.status.Equals("OK")))
            {
                respondStatus = "Invalid" + message;
                return false;
            }
            return true;
        }
    }
}